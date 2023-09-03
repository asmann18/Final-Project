using Atlet.Business.DTOs.Identity;
using Atlet.Business.Services.Interfaces.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {

        return Ok(await _authService.Login(userLoginDto));
    }
}
