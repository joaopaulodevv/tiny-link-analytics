using Microsoft.AspNetCore.Mvc;
namespace Shortener.Controllers;

using System.Net.Http.Headers;
using Shortener.Models;
using Shortener.Services.Interfaces;
using Shortener.DTOs;
using Microsoft.AspNetCore.Authorization;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ShortUrlsController : ControllerBase
{
    private readonly IShortUrlService _shortUrlService;
    
    public ShortUrlsController(IShortUrlService shortUrlService)
    {
        _shortUrlService = shortUrlService;
    }

    [HttpPost]
    public async Task<ActionResult<ShortUrlResponseDto>> Create([FromBody] ShortUrlRequestDto request)
    {
        string? UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if(UserId is null) return Unauthorized();

        ShortUrlResult response = await _shortUrlService.CreateShortUrlAsync(request, UserId);
        if(response.Status == ShortUrlStatus.URLAlreadyInUse)
        {
            return Conflict("URL already in use");
        }

        return CreatedAtAction(nameof(Get), new { id = response.ShortUrl?.Id }, response.ShortUrl);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ShortUrlResponseDto>> GetById(int id)
    {
        string? UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        if(UserId is null) return Unauthorized();
        
        ShortUrlResponseDto? response = await _shortUrlService.GetShortUrlById(id, UserId);
        return (response==null) ? NotFound() : Ok(response);
        
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShortUrlResponseDto>>> Get()
    {
        string? UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        //maybe redundant because this endpoint is protected, but just so the compiler shuts up
        if(UserId is null) return Unauthorized();



        IEnumerable<ShortUrlResponseDto> response = await _shortUrlService.ListShortUrlsAsync(UserId);
        return Ok(response);
    }
}   