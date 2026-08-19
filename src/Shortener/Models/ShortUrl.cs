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
    public string OriginalUrl { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public string OwnerId { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public AppUser? Owner { get; set; }

    public int Hits { get; set; } = 0;
}