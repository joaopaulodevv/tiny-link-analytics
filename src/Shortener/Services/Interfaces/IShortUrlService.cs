namespace Shortener.Services.Interfaces;
using Shortener.DTOs;

public interface IShortUrlService
{
    Task<ShortUrlResponseDto> CreateShortUrlAsync(ShortUrlRequestDto request);
    Task<IEnumerable<ShortUrlResponseDto>> ListShortUrlsAsync();
    Task<ShortUrlResponseDto?> GetShortUrlById(int id);
}