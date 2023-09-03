using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Identity;

public class UserLoginDto:IDto
{
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
}
