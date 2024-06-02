using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.Blogs;

namespace Atlet.Business.DTOs.Blogs.BlogCategoryDtos;

public class BlogCategoryRelationDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
}
