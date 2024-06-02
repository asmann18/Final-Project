using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.Identity;
using Atlet.Business.Exceptions.Identity;
using Atlet.Business.Services.Interfaces.Identity;
using Atlet.Core.Entities.Identity;
using Atlet.DataAccess.Contexts;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Atlet.Business.Services.Implementations.Identity;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;
    public UserService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IHttpContextAccessor contextAccessor, IMapper mapper, AppDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _contextAccessor = contextAccessor;
        _mapper = mapper;
        _context = context;
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
        var userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var user=await _userManager.FindByIdAsync(userId);

        var userInfoDto=_mapper.Map<UserInfoDto>(user);
        userInfoDto.Role = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        return new DataResultDto<UserInfoDto>(userInfoDto);
    }

    public async Task<DataResultDto<List<UserInfoDto>>> GetAllUserAsync()
    {
        var users = await _userManager.Users.Where(x=>x.Id!=_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
        var userDtos=_mapper.Map<List<UserInfoDto>>(users);
        for (int i = 0; i < users.Count; i++)
        {
            userDtos[i].Role =(await _userManager.GetRolesAsync(users[i]))[0];   
        }
        return new(userDtos);
    }

    
    public async Task<ResultDto> ChangeUserRoleAsync(UserChangeRoleDto dto)
    {
        var user =await _userManager.FindByIdAsync(dto.UserId);
        if (user is null)
            throw new UserNotFoundException();

        var role = await _roleManager.FindByIdAsync(dto.RoleId);
        if (role is null)
            throw new RoleNotFoundException();

        var oldRole = (await _userManager.GetRolesAsync(user)).First();
        if(oldRole is not null)
        {
            await _userManager.RemoveFromRoleAsync(user, oldRole);
            await _userManager.AddToRoleAsync(user, role.Name);
        }
        await _context.SaveChangesAsync();
        return new("successfully");
    }

    public async Task<DataResultDto<List<RoleGetDto>>> GetRolesAsync()
    {
        var roles = await _context.Roles.ToListAsync();

        var dtos=_mapper.Map<List<RoleGetDto>>(roles);
        return new(dtos);


    }

    public async Task<DataResultDto<UserInfoDto>> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if(user is null)
            throw new UserNotFoundException();
        var dto=_mapper.Map<UserInfoDto>(user);
        dto.Role =(await _userManager.GetRolesAsync(user))[0];

        return new(dto);
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
