using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.Identity;

namespace Atlet.Business.Services.Interfaces.Identity;

public interface IUserService
{

    Task<ResultDto> CreateUserAsync(UserPostDto userPostDto);
    Task<ResultDto> CreateRoleAsync();
    Task<DataResultDto<List<UserInfoDto>>> GetAllUserAsync();
    Task<DataResultDto<UserInfoDto>> GetUserInfo();
    Task<ResultDto> ChangeUserRoleAsync(UserChangeRoleDto dto);
    Task<DataResultDto<List<RoleGetDto>>> GetRolesAsync();

    Task<DataResultDto<UserInfoDto>> GetUserByIdAsync(string id);
}
