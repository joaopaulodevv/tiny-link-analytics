namespace tiny_link_analytics.Repositories{
using Microsoft.EntityFrameworkCore;
using tiny_link_analytics.Models;
using tiny_link_analytics.Repositories.Interfaces;

public class ShortUrlRepository : IShortUrlRepository
{
    private readonly AppDbContext _context;

    public ShortUrlRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ShortUrl> CreateAsync(ShortUrl shortUrl)
    {
        _context.ShortUrls.Add(shortUrl);
        await _context.SaveChangesAsync();
        return shortUrl;
    }

    public async Task DeleteAsync(int id)
    {
        var shortUrl = await _context.ShortUrls.FindAsync(id);
        if (shortUrl != null)
        {
            _context.ShortUrls.Remove(shortUrl);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<ShortUrl>> GetAllAsync()
    {
        return await _context.ShortUrls.ToListAsync();
    }

    public async Task<ShortUrl?> GetByIdAsync(int id)
    {
        return await _context.ShortUrls.FindAsync(id);
    }

    public async Task<ShortUrl> GetByShortCodeAsync(string shortCode)
    {
        return await _context.ShortUrls.FirstOrDefaultAsync(s => s.ShortCode == shortCode);
    }

    public async Task UpdateAsync(ShortUrl shortUrl)
    {
        _context.Entry(shortUrl).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
}