using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Identity;

public class RoleGetDto:IDto
{
    public string Id { get; set; }
    public string Name { get; set; }
}
