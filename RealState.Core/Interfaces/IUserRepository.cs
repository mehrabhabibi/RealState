namespace RealState.Core.Interfaces;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    Task AddAsync(User user);
    // Add other required methods
}