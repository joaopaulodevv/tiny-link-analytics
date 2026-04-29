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
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShortUrlResponseDto>>> Get()
    {
        IEnumerable<ShortUrlResponseDto> response = await _shortUrlService.ListShortUrlsAsync();
        return Ok(response);
    }
}   