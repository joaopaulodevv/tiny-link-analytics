namespace Shortener.Services;

using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using Shortener.Models;
using Shortener.Services.Interfaces;
using Shortener.Repositories.Interfaces;
using Shortener.Mappings;
using Shortener.DTOs;
using Base62;

public class ShortUrlService : IShortUrlService
{
    private readonly IShortUrlRepository _repository;


    public ShortUrlService(IShortUrlRepository repository)
        {
            _repository = repository;
        }

    public async Task<ShortUrlResult> CreateShortUrlAsync(ShortUrlRequestDto request, string userId)
    {   
        ShortUrl shortUrl = request.ToEntity();

        shortUrl.OwnerId = userId; 
        if(await _repository.GetShortUrlByUrlAsync(shortUrl.OriginalUrl) != null)
        {
            return new ShortUrlResult(ShortUrlStatus.URLAlreadyInUse, null);
        }

        await _repository.CreateAsync(shortUrl);
        ShortUrlResponseDto response = shortUrl.ToResponseDto();

        return new ShortUrlResult(ShortUrlStatus.Active, response);
    }

    public async Task<IEnumerable<ShortUrlResponseDto>> ListShortUrlsAsync(string userId)
    {
        IEnumerable<ShortUrl> shortUrls = await _repository.GetAllByUserIdAsync(userId);

        IEnumerable<ShortUrlResponseDto> response = shortUrls.Select(s => s.ToResponseDto());
        return response;
    }

    public async Task<ShortUrlResponseDto?> GetShortUrlAnalyticsById(int id, string userId)
        {
            ShortUrl? response = await _repository.GetAnalyticsByIdAsync(id, userId);
            return (response != null) ? response.ToResponseDto(): null;
        }

    public async Task<ShortUrlResponseDto?> GetShortUrlById(int id)
        {
            ShortUrl? response = await _repository.GetByIdAsync(id);
            return (response != null) ? response.ToResponseDto(): null;
        }


}