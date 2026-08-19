using System.ComponentModel.DataAnnotations;

namespace Shortener.DTOs;

public record ShortUrlResponseDto
{
    public int Id { get; set; }
    public required string OriginalUrl { get; set; } 

    public DateTime CreatedAt { get; set; }

    public int Hits { get; set; } = 0;
}

public record ShortUrlRequestDto
{
    [Required]
    [Url]
    [MaxLength(2048)]
    public required string OriginalUrl { get; set; } 
}

public enum ShortUrlStatus
{
    Active,
    Inactive,
    Expired,
    URLAlreadyInUse
}

public record ShortUrlResult(ShortUrlStatus Status, ShortUrlResponseDto? ShortUrl = null);
