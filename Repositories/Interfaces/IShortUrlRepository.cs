using tiny_link_analytics.Models;

namespace tiny_link_analytics.Repositories.Interfaces

{
    public interface IShortUrlRepository
    {
        Task<ShortUrl> CreateAsync(ShortUrl shortUrl);
        Task<ShortUrl?> GetByIdAsync(int id);
        Task<ShortUrl> GetByShortCodeAsync(string shortCode);
        Task<IEnumerable<ShortUrl>> GetAllAsync();
        Task UpdateAsync(ShortUrl shortUrl);
        Task DeleteAsync(int id);
    }
}