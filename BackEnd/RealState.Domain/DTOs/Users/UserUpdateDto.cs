using System.ComponentModel.DataAnnotations;

namespace RealState.Domain.DTOs.Users;

public class UserUpdateDto
{
    [Required]
    public int Id { get; set; }

    [MaxLength(100)]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Required, MinLength(8)]
    public string Password { get; set; }

    public bool? Active { get; set; }
}