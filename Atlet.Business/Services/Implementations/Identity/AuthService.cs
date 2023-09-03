using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.Identity;
using Atlet.Business.Exceptions.Identity;
using Atlet.Business.Services.Interfaces.Identity;
using Atlet.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Atlet.Business.Services.Implementations.Identity;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }


    public async Task<TokenResponseDto> CreateToken(AppUser user)
    {

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));

        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddHours(4),
            signingCredentials: signingCredentials
        );

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        string token = tokenHandler.WriteToken(jwtSecurityToken);

        return new TokenResponseDto(token, jwtSecurityToken.ValidTo, user.UserName);
    }

    public async Task<DataResultDto<TokenResponseDto>> Login(UserLoginDto userLoginDto)
    {
        var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
        if(user is null)
            throw new LoginFailedException();

        var isSuccess=await _userManager.CheckPasswordAsync(user,userLoginDto.Password);
        if(!isSuccess)
            throw new LoginFailedException();

        var tokenResponse = CreateToken(user).Result;
        return new DataResultDto<TokenResponseDto>(tokenResponse);
    }
}
