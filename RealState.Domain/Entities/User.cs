using RealState.Domain.Entities.Common;

public class User : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public Role Role { get; set; }
    public DateTime? LastLogin { get; set; }
}