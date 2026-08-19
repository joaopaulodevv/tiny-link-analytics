using Shortener.Models;

namespace Shortener.Repositories.Interfaces;

public interface IShortUrlRepository
{
    Task<ShortUrl> CreateAsync(ShortUrl shortUrl);
    Task<ShortUrl?> GetByIdAsync(int id);

    Task<ShortUrl?> GetShortUrlByUrlAsync(string url);

    Task<IEnumerable<ShortUrl>> GetAllAsync();
    Task UpdateAsync(ShortUrl shortUrl);
    Task DeleteAsync(int id);
}