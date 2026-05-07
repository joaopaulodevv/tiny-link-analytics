using System.ComponentModel.DataAnnotations;

namespace tiny_link_analytics.DTOs;

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