using Atlet.Business.DTOs.Blogs.BlogCategoryDtos;
using Atlet.Core.Entities.Blogs;
using AutoMapper;

namespace Atlet.Business.Mappers.Blogs;

public class BlogCategoryAutoMapper:Profile
{
    public BlogCategoryAutoMapper()
    {

        CreateMap<BlogCategory, BlogCategoryGetDto>().ReverseMap();
        CreateMap<BlogCategory, BlogCategoryPostDto>().ReverseMap();
        CreateMap<BlogCategory, BlogCategoryPutDto>().ReverseMap();
        CreateMap<BlogCategory, BlogCategoryRelationDto>().ReverseMap();
    }
}
