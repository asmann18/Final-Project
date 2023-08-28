using Atlet.Business.DTOs.Blogs.BlogCategoryDtos;
using FluentValidation;

namespace Atlet.Business.Validators.BlogValidators.BlogCategoryValidators;

public class BlogCategoryPostDtoValidator:AbstractValidator<BlogCategoryPostDto>
{
    public BlogCategoryPostDtoValidator()
    {
        RuleFor(c=>c.Name).NotEmpty().NotNull().MaximumLength(64).MinimumLength(2);
        
    }
}
