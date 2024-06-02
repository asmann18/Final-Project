using Atlet.Business.DTOs.Blogs.BlogDtos;
using Atlet.Business.DTOs.Blogs.BlogDtos;
using Atlet.Core.Entities.Blogs;
using AutoMapper;

namespace Atlet.Business.Mappers.Blogs;

public class BlogAutoMapper:Profile
{
    public BlogAutoMapper()
    {
        
    CreateMap<Blog, BlogGetDto>().ReverseMap();
    CreateMap<Blog, BlogPostDto>().ReverseMap();
    CreateMap<Blog, BlogPutDto>().ReverseMap();
    CreateMap<Blog, BlogRelationDto>().ReverseMap();

    }
}
