using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using RealState.Application.DTOs.Authentication;
using RealState.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

public class AuthService
{
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepo;

    public AuthService(IConfiguration config, IUserRepository userRepo)
    {
        _config = config;
        _userRepo = userRepo;
    }

    public async Task<AuthResponse> Login(string email, string password)
    {
        var user = await _userRepo.GetByEmailAsync(email);

        if (user == null || !VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            throw new UnauthorizedAccessException("Invalid credentials");

        return new AuthResponse
        {
            Token = GenerateToken(user),
            Role = user.Role
        };
    }

    private string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds,
            Issuer = _config["Jwt:Issuer"],
            Audience = _config["Jwt:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be empty");

        if (password.Length < 8)
            throw new ArgumentException("Password must be 8+ characters");

        if (storedHash.Length != 64)
            throw new ArgumentException("Invalid hash length (expected 64 bytes)");

        if (storedSalt.Length != 128)
            throw new ArgumentException("Invalid salt length (expected 128 bytes)");

        using var hmac = new HMACSHA512(storedSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
    }
}