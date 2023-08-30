using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.Blogs.BlogCategoryDtos;

namespace Atlet.Business.DTOs.Blogs.BlogDtos;

public class BlogGetDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public int BlogCategoryId { get; init; }
    public BlogCategoryRelationDto? BlogCategory { get; init; }
    public ICollection<int> BlogImages { get; init; } = new List<int>();
}
