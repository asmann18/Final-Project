using Atlet.Business.DTOs.E_Commerce.ProductCategoryDtos;
using FluentValidation;

namespace Atlet.Business.Validators.E_Commerce.ProductCategoryDtoValidators;

public class ProductCategoryPutDtoValidators:AbstractValidator<ProductCategoryPutDto>
{
    public ProductCategoryPutDtoValidators()
    {
        RuleFor(c=>c.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
        RuleFor(c=>c.Description).NotEmpty().NotNull().MinimumLength(3).MaximumLength(256);
        RuleFor(c=>c.Id).NotNull();
       
    }
}
