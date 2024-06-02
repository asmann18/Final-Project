using Atlet.Business.DTOs.Moves.PartDtos;
using FluentValidation;

namespace Atlet.Business.Validators.MoveValidators.PartValidators;

public class PartPutDtoValidator:AbstractValidator<PartPutDto>
{
    public PartPutDtoValidator()
    {
        RuleFor(p=>p.Name).NotNull().NotEmpty().MaximumLength(64).MinimumLength(3);
         

    }


}
