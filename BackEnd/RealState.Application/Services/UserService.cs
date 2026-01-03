using RealState.Domain.DTOs.Users;
using RealState.Core.Interfaces;
using RealState.Application.Mapping;
using System.Security.Cryptography;
using System.Text;

namespace RealState.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user.ToDto();
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var result = await _userRepository.GetAllAsync();
        return result.ToDto();
    }


    public async Task CreateUserAsync(UserCreateDto userCreateDto)
        => await _userRepository.AddAsync(userCreateDto.ToDataModel());

    public async Task UpdateUserAsync(UserUpdateDto userUpdateDto)
        => await _userRepository.UpdateAsync(userUpdateDto.ToDataModel());

    public async Task DeleteUserAsync(int id)
        => await _userRepository.DeleteAsync(id);

    public async Task<User> Authenticate(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user == null)
            return null;

        if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            return null;

        return user;
    }

    private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using var hmac = new HMACSHA512(storedSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(storedHash);
    }
}