using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.Identity;
using Atlet.Business.Exceptions.Identity;
using Atlet.Business.Services.Interfaces.Identity;
using Atlet.Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Atlet.Business.Services.Implementations.Identity;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHttpContextAccessor _contextAccessor;


    public UserService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _contextAccessor = contextAccessor;
    }

    public async Task<ResultDto> CreateUserAsync(UserPostDto userPostDto)
    {
        AppUser user = new AppUser
        {
            Fullname = userPostDto.Fullname,
            UserName = userPostDto.UserName,
            Email = userPostDto.Email,
        };
        var identityResult=await _userManager.CreateAsync(user,userPostDto.Password);
        if(!identityResult.Succeeded) {

            throw new UserCreateFailedException(string.Join(" ", identityResult.Errors.Select(e => e.Description)));

        }
        //await AddUserClaimAsync(user);
        await _userManager.AddToRoleAsync(user, "Member");
        return new ResultDto("User successfully created");
    }
    public async Task<ResultDto> CreateRoleAsync()
    {
        await _roleManager.CreateAsync(new IdentityRole("Member"));
        await _roleManager.CreateAsync(new IdentityRole("Moderator"));
        await _roleManager.CreateAsync(new IdentityRole("Admin"));
        return new ResultDto("Roles successfully created");
    }

    public async Task<DataResultDto<UserInfoDto>> GetUserInfo()
    {
        UserInfoDto userInfoDto = new UserInfoDto();
        userInfoDto.Username = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        userInfoDto.Email=_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
        userInfoDto.Role = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        return new DataResultDto<UserInfoDto>(userInfoDto,true,"user is ok");
    }
    //   private async Task AddUserClaimAsync(AppUser newUser)
    //   {
    //       List<Claim> userClaims = new List<Claim>
    //       {
    //           new Claim(ClaimTypes.NameIdentifier,newUser.Id),
    //           new Claim(ClaimTypes.Name,newUser.UserName),
    //           new Claim(ClaimTypes.Email,newUser.Email),


    //};
    //       await _userManager.AddClaimsAsync(newUser, userClaims);
    //   }
}
