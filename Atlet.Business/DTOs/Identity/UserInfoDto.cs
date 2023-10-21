using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.Identity;

namespace Atlet.Business.DTOs.Identity;

public class UserInfoDto:IDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    
}
