using Atlet.Business.DTOs.Blogs.BlogDtos;
using FluentValidation;

namespace Atlet.Business.Validators.BlogValidators.BlogValidators;

public class BlogPostDtoValidator:AbstractValidator<BlogPostDto>
{
    public BlogPostDtoValidator()
    {
        RuleFor(b=>b.Name).NotEmpty().NotNull().MaximumLength(64).MinimumLength(2);
        RuleFor(b => b.Description).NotEmpty().NotNull().MaximumLength(256).MinimumLength(3);
        RuleFor(p => p.BlogImagePaths).NotNull().NotEmpty();

    }
}
