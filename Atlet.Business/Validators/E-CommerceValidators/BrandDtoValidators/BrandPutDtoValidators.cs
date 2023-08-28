using Atlet.Business.DTOs.E_Commerce.BrandDtos;
using FluentValidation;

namespace Atlet.Business.Validators.E_CommerceValidators.BrandDtoValidators;

public class BrandPutDtoValidators:AbstractValidator<BrandPutDto>
{
    public BrandPutDtoValidators()
    {
        RuleFor(b=>b.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
        RuleFor(b=>b.Description).NotEmpty().NotNull().MinimumLength(3).MaximumLength(256);
        RuleFor(b=>b.Id).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(b=>b.ImageId).NotNull().GreaterThanOrEqualTo(0);
    }
}
