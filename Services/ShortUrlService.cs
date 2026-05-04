namespace tiny_link_analytics.Services{

using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using tiny_link_analytics.Models;
using AutoMapper;
using tiny_link_analytics.Services.Interfaces;
using tiny_link_analytics.Repositories.Interfaces;

public class ShortUrlService : IShortUrlService
{
    private readonly IMapper _mapper;
    private readonly IShortUrlRepository _repository;


    public ShortUrlService(IMapper mapper, IShortUrlRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

    public async Task<ShortUrlResponseDto> CreateShortUrlAsync(ShortUrlRequestDto request)
    {      
        ShortUrl shortUrl = _mapper.Map<ShortUrl>(request);
        await _repository.CreateAsync(shortUrl);
        ShortUrlResponseDto response = _mapper.Map<ShortUrlResponseDto>(shortUrl);

        return response;
    }

    public async Task<IEnumerable<ShortUrlResponseDto>> ListShortUrlsAsync()
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
        return response;
    }
}
}