namespace Shortener.Services;

using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using Shortener.Models;
using Shortener.Services.Interfaces;
using Shortener.Repositories.Interfaces;
using Shortener.Mappings;
using Shortener.DTOs;

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

    public async Task<ShortUrlResponseDto?> GetShortUrlById(int id)
        {
            ShortUrl? response = await _repository.GetByIdAsync(id);
            return (response != null) ? response.ToResponseDto(): null;
        }
}