using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Identity;

public class UserChangeRoleDto:IDto
{
    public string UserId { get; set; }
    public string RoleId { get; set; }
}
