namespace Shortener.Mappings;

using Shortener.Models;
using Shortener.DTOs;
using Base62;

public static class ShortUrlMappings
{
    private static string GenerateShortUrl(int id)
    {
        var converter = new Base62Converter();
        var encoded = converter.Encode(id.ToString());
        return encoded;

    }
    public static ShortUrlResponseDto ToResponseDto(this ShortUrl entity) => new()
    {
        Id = entity.Id,
        OriginalUrl = entity.OriginalUrl,
        CreatedAt = entity.CreatedAt,
        Hits = entity.Hits,
        ShortUrl = GenerateShortUrl(entity.Id)

    };


    public static ShortUrl ToEntity(this ShortUrlRequestDto dto) => new()
    {
        OriginalUrl = dto.OriginalUrl,
    };
}