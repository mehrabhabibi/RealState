using Microsoft.AspNetCore.Mvc;
using RealState.API.ViewModels.UserViewModel;
using RealState.API.Mapping;
using System.Security.Cryptography;
using System.Text;


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
    public async Task<IActionResult> CreateUser(UserCreateViewModel userCreateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (string.IsNullOrEmpty(userCreateViewModel.Password))
            return BadRequest("Password is required");

        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(userCreateViewModel.Password, out passwordHash, out passwordSalt);

        await _userService.CreateUserAsync(userCreateViewModel.ToDto(passwordHash, passwordSalt));

        return Ok(new { message = "User created successfully" });
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(UserUpdateViewModel userUpdateViewModel)
    {
        if (GetUser(userUpdateViewModel.Id) == null) return NotFound();
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