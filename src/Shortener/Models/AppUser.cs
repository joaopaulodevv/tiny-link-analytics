using Microsoft.AspNetCore.Identity;

namespace Shortener.Models;

public class AppUser : IdentityUser
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}