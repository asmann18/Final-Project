using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Blogs.BlogDtos;

public class BlogRelationDto:IDto
{

    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
}
