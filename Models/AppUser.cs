using Microsoft.AspNetCore.Identity;

namespace tiny_link_analytics.Models;

public class AppUser : IdentityUser
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}