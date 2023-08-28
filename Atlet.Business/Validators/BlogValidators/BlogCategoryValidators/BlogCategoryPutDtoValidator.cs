using Atlet.Business.DTOs.Blogs.BlogCategoryDtos;
using FluentValidation;

namespace Atlet.Business.Validators.BlogValidators.BlogCategoryValidators;

public class BlogCategoryPutDtoValidator:AbstractValidator<BlogCategoryPutDto>
{
    public BlogCategoryPutDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull().MaximumLength(64).MinimumLength(2);

    }
}
