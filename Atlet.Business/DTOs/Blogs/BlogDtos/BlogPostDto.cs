using Atlet.Business.DTOs.Abstract;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.DTOs.Blogs.BlogDtos;

public class BlogPostDto:IDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public int BlogCategoryId { get; init; }
    public IFormFile[] BlogImagesF { get; init; }
}
