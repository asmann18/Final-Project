using Atlet.Business.DTOs.E_Commerce.AromaDtos;
using FluentValidation;

namespace Atlet.Business.Validators.E_Commerce.AromaDtoValidators;

public class AromaPutDtoValidators:AbstractValidator<AromaPutDto>
{
    public AromaPutDtoValidators()
    {
        RuleFor(a=>a.Id).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(a=>a.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(64);
    }
}
