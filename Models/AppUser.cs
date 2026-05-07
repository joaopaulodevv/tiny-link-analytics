

using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    public DateTime CreatedAt { get; set; }

}