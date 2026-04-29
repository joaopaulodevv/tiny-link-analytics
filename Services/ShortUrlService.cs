namespace tiny_link_analytics.Services;

using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using tiny_link_analytics.Models;
using AutoMapper;
using tiny_link_analytics.Services.Interfaces;

public class ShortUrlService : IShortUrlService
{
    private readonly IMapper _mapper;

    public ShortUrlService(IMapper mapper)
        {
            _mapper = mapper;
        }

    public Task<ShortUrlResponseDto> CreateShortUrlAsync(ShortUrlRequestDto request)
    {      

        ShortUrl newShortUrl = new ShortUrl
        {
            OriginalUrl = "request.OriginalUrl",
            ShortCode = "6767",
            CreatedAt = DateTime.UtcNow
        };

        ShortUrlResponseDto response = _mapper.Map<ShortUrlResponseDto>(newShortUrl);

        return Task.FromResult(response);
    }

    public Task<IEnumerable<ShortUrlResponseDto>> ListShortUrlsAsync()
    {
       ShortUrl newShortUrl = new ShortUrl
        {
            OriginalUrl = "request.OriginalUrl",
            ShortCode = "6767",
            CreatedAt = DateTime.UtcNow
        };

        ShortUrl newShortUrl2 = new ShortUrl
        {
            OriginalUrl = "request.Origina2lUrl",
            ShortCode = "67672",
            CreatedAt = DateTime.UtcNow
        };
        IEnumerable<ShortUrl> shortUrls = new List<ShortUrl> { newShortUrl, newShortUrl2 };
        IEnumerable<ShortUrlResponseDto> response = _mapper.Map<IEnumerable<ShortUrlResponseDto>>(shortUrls);
        return Task.FromResult(response);
    }
}