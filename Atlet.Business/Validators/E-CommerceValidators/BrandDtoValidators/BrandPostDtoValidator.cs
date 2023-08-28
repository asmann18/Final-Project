using Atlet.Business.DTOs.E_Commerce.BrandDtos;
using FluentValidation;

namespace Atlet.Business.Validators.E_CommerceValidators.BrandDtoValidators;

public class BrandPostDtoValidator:AbstractValidator<BrandPostDto>
{
    public BrandPostDtoValidator()
    {
       RuleFor(b=>b.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
       RuleFor(b=>b.Description).NotEmpty().NotNull().MinimumLength(3).MaximumLength(256);
    }
}
