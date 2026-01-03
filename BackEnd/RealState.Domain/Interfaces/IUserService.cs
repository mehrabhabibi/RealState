using RealState.Domain.DTOs.Users;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(int id);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task CreateUserAsync(UserCreateDto dto);
    Task UpdateUserAsync(UserUpdateDto dto);
    Task DeleteUserAsync(int Id);
    Task<User> Authenticate(string email, string password);
}