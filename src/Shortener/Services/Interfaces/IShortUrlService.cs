namespace Shortener.Services.Interfaces;
using Shortener.DTOs;

public interface IShortUrlService
{
    Task<ShortUrlResult> CreateShortUrlAsync(ShortUrlRequestDto request, string userId);
    Task<IEnumerable<ShortUrlResponseDto>> ListShortUrlsAsync(string userId);
    Task<ShortUrlResponseDto?> GetShortUrlById(int id, string userId);
}