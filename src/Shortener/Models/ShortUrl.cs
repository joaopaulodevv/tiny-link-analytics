using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shortener.Models;

[Index(nameof(OriginalUrl), IsUnique = true)]
public class ShortUrl
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string OriginalUrl { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(AppUser))]
    public AppUser? Owner { get; set; }

    public int Hits { get; set; } = 0;
}