using RealState.Domain.DTOs.Users;

namespace RealState.Application.Mapping;

public static class UserMapper
{
    public static User ToDataModel(this UserCreateDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Role = dto.Role,
            Active = true,
            Deleted = false,
            CreatedAt = DateTime.UtcNow,
            PasswordHash = dto.PasswordHash,
            PasswordSalt = dto.PasswordSalt
        };
    }

    public static User ToDataModel(this UserUpdateDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };
    }

    public static UserDto ToDto(this User DataModel)
    {
        return new UserDto
        {
            FirstName = DataModel.FirstName,
            LastName = DataModel.LastName,
            Email = DataModel.Email,
            Role = DataModel.Role,
        };
    }

    public static IEnumerable<UserDto> ToDto(this IEnumerable<User> dataModels)
    {
        if (dataModels == null) return null;
        return dataModels.Select(c => c.ToDto());
    }
}