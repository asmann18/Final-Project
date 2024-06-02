using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.Blogs.BlogDtos;
using Atlet.Core.Entities.Blogs;

namespace Atlet.Business.DTOs.Blogs.BlogCategoryDtos;

public class BlogCategoryGetDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public ICollection<BlogRelationDto> Blogs { get; init; } = new List<BlogRelationDto>();
}
