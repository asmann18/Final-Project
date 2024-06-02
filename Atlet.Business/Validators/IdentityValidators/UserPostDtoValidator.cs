using Atlet.Business.DTOs.Identity;
using FluentValidation;

namespace Atlet.Business.Validators.IdentityValidators;

public class UserPostDtoValidator:AbstractValidator<UserPostDto>
{
    public UserPostDtoValidator()
    {
        RuleFor(p => p.Fullname).MaximumLength(100);   
        RuleFor(p => p.UserName).NotEmpty().NotNull().MaximumLength(100).MinimumLength(3);   
        RuleFor(p => p.Password).NotEmpty().NotNull().MaximumLength(100).MinimumLength(6);   
        RuleFor(p => p.PasswordConfirm).NotEmpty().NotNull().MaximumLength(100).MinimumLength(6).Equal(s=>s.Password);   
        RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress().MaximumLength(256);   
    }
}
