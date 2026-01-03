using RealState.API.ViewModels.User;
using RealState.Domain.DTOs.Users;

namespace RealState.API.Mapping;

public static class UserMapper
{
    public static UserCreateDto ToDto(this UserCreateViewModel viewModel, byte[] passwordHash, byte[] passwordSalt)
    {
        return new UserCreateDto
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            Password = viewModel.Password,
            Role = viewModel.Role,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
    }

    public static UserUpdateDto ToDto(this UserUpdateViewModel viewModel)
    {
        return new UserUpdateDto
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            Password = viewModel.Password
        };
    }

    public static IEnumerable<UserViewModel> ToViewModel(this IEnumerable<UserDto> dtos)
    {
        return dtos.Select(c => c.ToViewModel());
    }

    public static UserViewModel ToViewModel(this UserDto userDto)
    {
        return new UserViewModel
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email
        };
    }
}