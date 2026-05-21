using Shortener.Models;

namespace Shortener.Services.Interfaces;

public interface ITokenService
{
    (string Token, DateTime ExpiresAt) GenerateToken(AppUser user, IList<string> roles);
}