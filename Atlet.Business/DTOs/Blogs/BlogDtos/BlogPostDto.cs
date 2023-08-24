using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Blogs.BlogDtos;

public class BlogPostDto:IDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public int BlogCategoryId { get; init; }
    public ICollection<int> BlogImages { get; init; } = new List<int>();
}
