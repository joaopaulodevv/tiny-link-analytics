namespace tiny_link_analytics.Models;

public record ShortUrlResponseDto
{
    public int Id { get; set; }
    public string OriginalUrl { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public int Hits { get; set; } = 0;
}

public record ShortUrlRequestDto
{
    public string OriginalUrl { get; set; } = string.Empty;
}