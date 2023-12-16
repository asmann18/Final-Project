using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Identity;

public class UserInfoDto:IDto
{
    public string Id { get; init; }
    public string Username { get; init; }
    public string Email { get; init; }
    public string Role { get; set; }
    public string? Fullname { get; init; }



}
