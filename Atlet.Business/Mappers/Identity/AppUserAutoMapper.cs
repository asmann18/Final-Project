using Atlet.Business.DTOs.Identity;
using Atlet.Core.Entities.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Atlet.Business.Mappers.Identity;

public class AppUserAutoMapper:Profile
{
    public AppUserAutoMapper()
    {
        CreateMap<AppUser,UserInfoDto>().ReverseMap();
        CreateMap<IdentityRole,RoleGetDto>().ReverseMap();
    }
}
