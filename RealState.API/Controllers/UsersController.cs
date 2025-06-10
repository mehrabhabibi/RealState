using Microsoft.AspNetCore.Mvc;
using RealState.API.ViewModels.UserViewModel;
using RealState.API.Mapping;


namespace RealState.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
        => Ok(await _userService.GetUserByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        => Ok(await _userService.GetAllUsersAsync());

    [HttpPost]
    public async Task CreateUser(UserCreateViewModel userCreateViewModel)
    {
        await _userService.CreateUserAsync(userCreateViewModel.ToDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(UserUpdateViewModel userUpdateViewModel)
    {
        if (GetUser(userUpdateViewModel.Id) != null) return NotFound();
        await _userService.UpdateUserAsync(userUpdateViewModel.ToDto());
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }
}