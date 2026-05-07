namespace tiny_link_analytics.Services.Interfaces;

using Microsoft.AspNetCore.Identity.Data;
using tiny_link_analytics.DTOs;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterRequest request);
    Task<AuthResult> LoginAsync(LoginRequest request);
    Task<UserProfileDto?> GetUserByIdAsync(string userId);
}
