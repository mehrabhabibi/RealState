using System.ComponentModel.DataAnnotations;

namespace RealState.API.ViewModels.UserViewModel;

public class UserCreateViewModel
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; }

    [Required, MaxLength(100)]
    public string LastName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 8)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
     ErrorMessage = "Password must contain uppercase, lowercase, number, and special character")]
    public string Password { get; set; }
    public Role Role { get; set; }
}