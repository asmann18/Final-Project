using Atlet.Business.DTOs.E_Commerce.AromaDtos;
using FluentValidation;

namespace Atlet.Business.Validators.E_Commerce.AromaDtoValidators;

public class AromaPostDtoValidators:AbstractValidator<AromaPostDto>
{
    public AromaPostDtoValidators()
    {
      RuleFor(a=>a.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(64);

    }
}
