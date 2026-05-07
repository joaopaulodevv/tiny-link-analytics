using tiny_link_analytics.Models;

namespace tiny_link_analytics.Services;

public interface ITokenService
{
    (string Token, DateTime ExpiresAt) GenerateToken(AppUser user, IList<string> roles);
}