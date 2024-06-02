using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using FluentValidation;

namespace Atlet.Business.Validators.E_CommerceValidators;

public class ProductPostDtoValidators:AbstractValidator<ProductPostDto>
{
    public ProductPostDtoValidators()
    {
        RuleFor(p=>p.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
        RuleFor(p=>p.Description).NotEmpty().NotNull().MinimumLength(3).MaximumLength(256);
        RuleFor(p => p.Price).NotNull().GreaterThan(0);
        RuleFor(p => p.Count).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(p => p.Discount).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(p => p.ProductImagesF).NotNull().NotEmpty();
    }
}
