namespace Shortener.Services.Interfaces;

using Microsoft.AspNetCore.Identity.Data;
using Shortener.DTOs;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterRequest request);
    Task<AuthResult> LoginAsync(LoginRequest request);
    Task<UserProfileDto?> GetUserByIdAsync(string userId);
}
