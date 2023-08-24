using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Blogs.BlogCategoryDtos;

public class BlogCategoryPutDto:IDto
{
    public int Id { get; init; }     
    public string Name { get; init; } 

}
