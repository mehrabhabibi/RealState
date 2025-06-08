namespace RealState.Application.DTOs.Authentication;

public class AuthResponse
{
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
    public Role Role { get; set; }
    public int UserId { get; set; }
}