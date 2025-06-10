using RealState.API.ViewModels.UserViewModel;
using RealState.Domain.DTOs.Users;

namespace RealState.API.Mapping;

public static class UserMapper
{
    public static UserCreateDto ToDto(this UserCreateViewModel viewModel)
    {
        return new UserCreateDto
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            Password = viewModel.Password,
            Role = viewModel.Role,
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
}