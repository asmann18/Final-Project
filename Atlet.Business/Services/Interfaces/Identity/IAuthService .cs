using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.Business.Services.Interfaces.Identity;

public interface IAuthService
{
    Task<IActionResult> Login(UserLoginDto userLoginDto);
    //Task<DataResultDto<string>  >
}
