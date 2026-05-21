namespace Shortener.Mappings;

using Shortener.Models;
using Shortener.DTOs;

public static class ShortUrlMappings
{
    public static ShortUrlResponseDto ToResponseDto(this ShortUrl entity) => new()
    {
        Id = entity.Id,
        OriginalUrl = entity.OriginalUrl,
        CreatedAt = entity.CreatedAt,
        Hits = entity.Hits
    };

    public static ShortUrl ToEntity(this ShortUrlRequestDto dto) => new()
    {
        OriginalUrl = dto.OriginalUrl
    };
}