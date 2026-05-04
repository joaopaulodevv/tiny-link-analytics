namespace tiny_link_analytics.Services{

using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using tiny_link_analytics.Models;
using tiny_link_analytics.Services.Interfaces;
using tiny_link_analytics.Repositories.Interfaces;

public class ShortUrlService : IShortUrlService
{
    private readonly IShortUrlRepository _repository;


    public ShortUrlService(IShortUrlRepository repository)
        {
            _repository = repository;
        }

    public async Task<ShortUrlResponseDto> CreateShortUrlAsync(ShortUrlRequestDto request)
    {   
        ShortUrl shortUrl = request.ToEntity();
        await _repository.CreateAsync(shortUrl);
        ShortUrlResponseDto response = shortUrl.ToResponseDto();

        return response;
    }

    public async Task<IEnumerable<ShortUrlResponseDto>> ListShortUrlsAsync()
    {
        IEnumerable<ShortUrl> shortUrls = await _repository.GetAllAsync();

        IEnumerable<ShortUrlResponseDto> response = shortUrls.Select(s => s.ToResponseDto());
        return response;
    }
}
}