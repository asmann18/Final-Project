using Atlet.Business.DTOs.E_Commerce.CommentDtos;
using FluentValidation;

namespace Atlet.Business.Validators.E_CommerceValidators.CommentDtoValidators;

public class CommentPostDtoValidators:AbstractValidator<CommentPostDto>
{
    public CommentPostDtoValidators()
    {
        RuleFor(c=>c.Text).NotNull().NotEmpty().MinimumLength(1).MaximumLength(300);
        RuleFor(c=>c.ProductId).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(c=>c.ParentId).GreaterThanOrEqualTo(0);
        RuleFor(c=>c.UserId).NotNull().GreaterThanOrEqualTo(0);

    }
}
