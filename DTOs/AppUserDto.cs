
using System.ComponentModel.DataAnnotations;

public record AppUserRegisterDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public required string ConfirmPassword { get; set; }
}

public record AppUserLoginDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
}