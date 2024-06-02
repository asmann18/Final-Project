using Atlet.Business.DTOs.Identity;
using Atlet.Business.Services.Interfaces.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register(UserPostDto userPostDto)
    {
        var response = await _userService.CreateUserAsync(userPostDto);
        return StatusCode((int)response.statusCode, response.message);
    }
    [HttpGet("[action]")]
    [Authorize]
    public async Task<IActionResult> UserGetInfo()
    {
        return Ok(await _userService.GetUserInfo());
    }

    [HttpGet("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await _userService.GetAllUserAsync());
    }

    [HttpPost("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChangeUserRole([FromBody]UserChangeRoleDto dto)
    {
        return Ok(await _userService.ChangeUserRoleAsync(dto));
    }

    [HttpGet("[action]")]
    [Authorize(Roles="Admin")]
    public async Task<IActionResult> GetAllRolesAsync()
    {
        return Ok(await _userService.GetRolesAsync());
    }
    [HttpGet("[action]/{id}")]
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> GetUserInfoByIdAsync(string id)
    {
        return Ok(await _userService.GetUserByIdAsync(id));
    }
    //[HttpPost("[action]")]
    //public async Task<IActionResult> CreateRoles()
    //{
    //    return Ok(await _userService.CreateRoleAsync());
    //}
}
