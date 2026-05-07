namespace tiny_link_analytics.Services.Interfaces;
using tiny_link_analytics.Models;

public interface IShortUrlService
{
    Task<ShortUrlResponseDto> CreateShortUrlAsync(ShortUrlRequestDto request);
    Task<IEnumerable<ShortUrlResponseDto>> ListShortUrlsAsync();
    Task<ShortUrlResponseDto?> GetShortUrlById(int id);
}