using Atlet.Business.DTOs.Identity;
using Atlet.Business.Services.Interfaces.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

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
        var result = await _authService.Login(userLoginDto);

        Response.Cookies.Append("tokenData", JsonConvert.SerializeObject(result), new CookieOptions
        {
            SameSite = SameSiteMode.None,
            Secure = true 
        });
        return Ok(result);
    }
}
