using Atlet.Business.DTOs.Moves.MoveDtos;
using FluentValidation;

namespace Atlet.Business.Validators.MoveValidators.MoveValidators;

public class MovePutDtoValidator:AbstractValidator<MovePutDto>
{
    public MovePutDtoValidator()
    {
        RuleFor(m => m.Name).NotEmpty().NotNull().MaximumLength(64).MinimumLength(3);
        RuleFor(m => m.Description).NotEmpty().NotNull().MaximumLength(5000).MinimumLength(3);

    }
}
