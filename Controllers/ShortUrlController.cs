using Microsoft.AspNetCore.Mvc;
namespace tiny_link_analytics.Controllers;

using tiny_link_analytics.Models;
using tiny_link_analytics.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ShortUrlController : ControllerBase
{
    private readonly IShortUrlService _shortUrlService;
    
    public ShortUrlController(IShortUrlService shortUrlService)
    {
        _shortUrlService = shortUrlService;
    }

    [HttpPost]
    public async Task<ActionResult<ShortUrlResponseDto>> Create([FromBody] ShortUrlRequestDto request)
    {
        
        ShortUrlResponseDto response = await _shortUrlService.CreateShortUrlAsync(request);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShortUrlResponseDto>>> Get()
    {
        IEnumerable<ShortUrlResponseDto> response = await _shortUrlService.ListShortUrlsAsync();
        return Ok(response);
    }
}   