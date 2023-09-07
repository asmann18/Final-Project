using Atlet.Business.DTOs.Moves.PartDtos;
using FluentValidation;

namespace Atlet.Business.Validators.MoveValidators.PartValidators;

public class PartPostDtoValidator:AbstractValidator<PartPostDto>
{
    public PartPostDtoValidator()
    {
        RuleFor(p=>p.Name).NotEmpty().NotNull().MaximumLength(64).MinimumLength(2);
        RuleFor(b => b.ImagePath).NotNull().NotEmpty();

    }
}
