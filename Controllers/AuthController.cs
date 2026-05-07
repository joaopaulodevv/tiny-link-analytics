using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using tiny_link_analytics.DTOs;
using tiny_link_analytics.Services.Interfaces;

namespace tiny_link_analytics.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request);
        return result.Outcome switch
        {
            AuthOutcome.Success => Ok(result.Data),
            AuthOutcome.EmailAlreadyRegistered => Conflict(new { message = "Email já cadastrado." }),
            AuthOutcome.ValidationFailed => BadRequest(new { errors = result.Errors }),
            _ => StatusCode(500)
        };
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);
        return result.Outcome switch
        {
            AuthOutcome.Success => Ok(result.Data),
            AuthOutcome.LockedOut => Unauthorized(new { message = "Conta bloqueada temporariamente." }),
            AuthOutcome.InvalidCredentials => Unauthorized(new { message = "Credenciais inválidas." }),
            _ => StatusCode(500)
        };
    }

    [HttpGet("me")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public async Task<IActionResult> Me()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId is null) return Unauthorized();

        var profile = await _authService.GetUserByIdAsync(userId);
        if (profile is null) return NotFound();

        return Ok(profile);
    }
}
