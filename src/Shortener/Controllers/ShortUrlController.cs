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
        
        ShortUrlResponseDto response = await _shortUrlService.CreateShortUrlAsync(request);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ShortUrlResponseDto>> GetById(int id)
    {
        ShortUrlResponseDto? response = await _shortUrlService.GetShortUrlById(id);
        return (response==null) ? NotFound() : Ok(response);
        
    }

    
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ShortUrlResponseDto>>> Get()
    {
        IEnumerable<ShortUrlResponseDto> response = await _shortUrlService.ListShortUrlsAsync();
        return Ok(response);
    }
}   