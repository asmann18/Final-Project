using Atlet.Business.DTOs.E_Commerce.ProductCategoryDtos;
using FluentValidation;

namespace Atlet.Business.Validators.E_CommerceValidators.ProductCategoryDtoValidators;

public class ProductCategoryPostDtoValidators:AbstractValidator<ProductCategoryPostDto>
{
    public ProductCategoryPostDtoValidators()
    {
      RuleFor(c=>c.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
      RuleFor(c=>c.Description).NotEmpty().NotNull().MinimumLength(3).MaximumLength(256);

    }
}
