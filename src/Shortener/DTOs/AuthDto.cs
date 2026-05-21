namespace Shortener.DTOs;

public record AuthResponseDto(string Token, DateTime ExpiresAt);

public record UserProfileDto(string Id, string? Email, DateTime CreatedAt);

public enum AuthOutcome
{
    Success,
    EmailAlreadyRegistered,
    ValidationFailed,
    InvalidCredentials,
    LockedOut
}

public record AuthResult(AuthOutcome Outcome, AuthResponseDto? Data = null, IEnumerable<string>? Errors = null);
