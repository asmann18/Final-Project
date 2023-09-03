using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Identity;

public class UserPostDto:IDto
{
    public string? Fullname { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string PasswordConfirm { get;init; }
}
