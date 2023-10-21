using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.Identity;
using Atlet.Core.Entities.Identity;

namespace Atlet.Business.Services.Interfaces.Identity;

public interface IAuthService
{
    Task<DataResultDto<TokenResponseDto>> Login(UserLoginDto userLoginDto);
    Task<TokenResponseDto> CreateToken(AppUser user);

}
