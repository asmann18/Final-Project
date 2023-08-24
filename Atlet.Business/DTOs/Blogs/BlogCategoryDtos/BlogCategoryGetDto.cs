using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.Blogs;

namespace Atlet.Business.DTOs.Blogs.BlogCategoryDtos;

public class BlogCategoryGetDto:IDto
{
    public string Name { get; init; }
    public ICollection<Blog> Blogs { get; init; } = new List<Blog>();
}
