using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.Identity;

namespace Atlet.Business.Services.Interfaces.Identity;

public interface IUserService
{

    Task<ResultDto> CreateUserAsync(UserPostDto userPostDto);
    Task<ResultDto> CreateRoleAsync();
    Task<DataResultDto<UserInfoDto>> GetUserInfo();
}
