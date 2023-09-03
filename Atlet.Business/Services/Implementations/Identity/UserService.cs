using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.Identity;
using Atlet.Business.Exceptions.Identity;
using Atlet.Business.Services.Interfaces.Identity;
using Atlet.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Atlet.Business.Services.Implementations.Identity;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
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
}
