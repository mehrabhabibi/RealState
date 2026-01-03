using System.ComponentModel.DataAnnotations;

namespace RealState.Domain.DTOs.Users;

public class UserCreateDto
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; }

    [Required, MaxLength(100)]
    public string LastName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, MinLength(8)]
    public string Password { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    [Required]
    public Role Role { get; set; } = Role.EndUser;
}