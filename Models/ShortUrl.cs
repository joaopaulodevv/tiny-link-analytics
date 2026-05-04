using System.ComponentModel.DataAnnotations;

namespace tiny_link_analytics.Models;
public class ShortUrl
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string OriginalUrl { get; set; } = string.Empty;
    
    public string ShortCode { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int Hits { get; set; } = 0;
}