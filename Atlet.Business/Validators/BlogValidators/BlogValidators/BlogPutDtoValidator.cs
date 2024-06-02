using Atlet.Business.DTOs.Blogs.BlogDtos;
using FluentValidation;

namespace Atlet.Business.Validators.BlogValidators.BlogValidators;


internal class BlogPutDtoValidator:AbstractValidator<BlogPutDto>
{
    public BlogPutDtoValidator()
    {
        RuleFor(b => b.Name).NotEmpty().NotNull().MaximumLength(64).MinimumLength(2);
        RuleFor(b => b.Description).NotEmpty().NotNull().MaximumLength(5000).MinimumLength(3);
    }
}
