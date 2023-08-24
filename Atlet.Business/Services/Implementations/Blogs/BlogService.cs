using Atlet.Business.DTOs.Blogs.BlogDtos;
using Atlet.Business.DTOs.Common;
using Atlet.Business.Exceptions.Blogs.BlogExceptions;
using Atlet.Business.Services.Interfaces.Blogs;
using Atlet.Core.Entities.Blogs;
using Atlet.DataAccess.Repostories.Interfaces.Blogs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.Blogs;

public class BlogService : IBlogService
{

    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public BlogService(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<ResultDto> CreateBlogAsync(BlogPostDto blogPostDto)
    {
        var isExist=await _blogRepository.IsExistAsync(b=>b.Name == blogPostDto.Name);
        if(isExist)
            throw new BlogAlreadyExistException();
        var blog=_mapper.Map<Blog>(blogPostDto);
        await _blogRepository.CreateAsync(blog);
        return new ResultDto(true, "Blog successfully created");
    }

    public async Task<ResultDto> DeleteBlogAsync(int Id)
    {
        var blog=await _blogRepository.GetByIdAsync(Id);
        if(blog is null)
             throw new BlogNotFoundException();

        _blogRepository.Delete(blog);
        await _blogRepository.SaveAsync();
        return new ResultDto(true, "Blog successfully deleted");

    }

    public async Task<DataResultDto<List<BlogGetDto>>> GetAllBlogsAsync(string? search)
    {
        var blogs=await _blogRepository.GetFiltered(b=> !string.IsNullOrWhiteSpace(search) ? b.Name.ToLower().Contains(search.ToLower()) : true,"BlogCagetory" ).ToListAsync();
        if(blogs.Count==0) throw new BlogNotFoundException();
        var blogDtos=_mapper.Map<List<BlogGetDto>>(blogs);
        return new DataResultDto<List<BlogGetDto>>(blogDtos);
    }

    public async Task<DataResultDto<BlogGetDto>> GetBlogByIdAsync(int Id)
    {
        var blog=await _blogRepository.GetByIdAsync(Id,"BlogCategory");
        if (blog is null)
            throw new BlogNotFoundException();
        var blogDto=_mapper.Map<BlogGetDto>(blog);
        return new DataResultDto<BlogGetDto>(blogDto);
    }

    public async Task<ResultDto> UpdateBlogAsync(BlogPutDto blogPutDto)
    {
        var isExit=await _blogRepository.IsExistAsync(b=>b.Name==blogPutDto.Name && b.Id!=blogPutDto.Id);
        if(isExit)
            throw new BlogAlreadyExistException();
        isExit = await _blogRepository.IsExistAsync(b => b.Id == blogPutDto.Id);
        if (!isExit)
            throw new BlogNotFoundException();

        var blog = _mapper.Map<Blog>(blogPutDto);
        _blogRepository.Update(blog);
        await _blogRepository.SaveAsync();
        return new ResultDto(true, "Blog is successfully uptaded");
    }
}
