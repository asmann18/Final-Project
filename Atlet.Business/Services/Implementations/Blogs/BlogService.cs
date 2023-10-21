using Atlet.Business.DTOs.Blogs.BlogDtos;
using Atlet.Business.DTOs.Common;
using Atlet.Business.Exceptions.Blogs.BlogExceptions;
using Atlet.Business.Services.Interfaces;
using Atlet.Business.Services.Interfaces.Blogs;
using Atlet.Core.Entities.Blogs;
using Atlet.Core.Entities.Blogs.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.Blogs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.Blogs;

public class BlogService : IBlogService
{

    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;

    public BlogService(IBlogRepository blogRepository, IMapper mapper, IImageService imageService)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<ResultDto> CreateBlogAsync(BlogPostDto blogPostDto)
    {
        var isExist=await _blogRepository.IsExistAsync(b=>b.Name == blogPostDto.Name);
        if(isExist)
            throw new BlogAlreadyExistException();
        var blog=_mapper.Map<Blog>(blogPostDto);
        await _blogRepository.CreateAsync(blog);
        await _imageService.CreateBlogImages(blog.Id, blogPostDto.BlogImagesF);
        return new ResultDto(true, "Blog successfully created");
    }

    public async Task<ResultDto> DeleteBlogAsync(int Id)
    {
        var blog=await _blogRepository.GetByIdAsync(Id);
        if(blog is null)
             throw new BlogNotFoundException();

        _blogRepository.Delete(blog);
        await _imageService.DeleteBlogImages(Id);
        await _blogRepository.SaveAsync();
        return new ResultDto(true, "Blog successfully deleted");

    }

    public async Task<DataResultDto<List<BlogGetDto>>> GetAllBlogsAsync(string? search)
    {
        var blogs=await _blogRepository.GetFiltered(b=> !string.IsNullOrWhiteSpace(search) ? b.Name.ToLower().Contains(search.ToLower()) : true,"BlogCategory" ).ToListAsync();
        if(blogs.Count==0) throw new BlogNotFoundException();
        var blogDtos=_mapper.Map<List<BlogGetDto>>(blogs);
        foreach (var item in blogDtos)
        {
            item.BlogImagePaths = await _imageService.GetBlogImageUrlsByIdasync(item.Id);
        }
        return new DataResultDto<List<BlogGetDto>>(blogDtos);
    }

    public async Task<DataResultDto<BlogGetDto>> GetBlogByIdAsync(int Id)
    {
        var blog=await _blogRepository.GetByIdAsync(Id,"BlogCategory");
        if (blog is null)
            throw new BlogNotFoundException();
        var blogDto=_mapper.Map<BlogGetDto>(blog);
        blogDto.BlogImagePaths = await _imageService.GetBlogImageUrlsByIdasync(blogDto.Id);

        return new DataResultDto<BlogGetDto>(blogDto);
    }

    public async Task<ResultDto> UpdateBlogAsync(BlogPutDto blogPutDto)
    {
        var isExit=await _blogRepository.IsExistAsync(b=>b.Name==blogPutDto.Name && b.Id!=blogPutDto.Id);
        if(isExit)
            throw new BlogAlreadyExistException();
        var uptadedBlog = await _blogRepository.GetByIdAsync(blogPutDto.Id);
        if (uptadedBlog is null)
            throw new BlogNotFoundException();

        var blog = _mapper.Map(blogPutDto,uptadedBlog);
        if(blogPutDto.BlogImagesF is not null)
        {
            var images=await _imageService.UpdateBlogImages(blogPutDto.Id,blogPutDto.BlogImagesF);
            blog.BlogImages = images;
        }

        _blogRepository.Update(blog);
        await _blogRepository.SaveAsync();
        return new ResultDto(true, "Blog is successfully uptaded");
    }

    public async Task<ResultDto> AddBlogImages(int blogId,BlogImage BlogImage)
    {
        var blog=await _blogRepository.GetByIdAsync(blogId);

        blog.BlogImages.Add(BlogImage);
        await _blogRepository.SaveAsync();
        return new ResultDto("successfully");
    }

    public async Task<ResultDto> RemoveBlogImages(int blogId, BlogImage BlogImage)
    {
        var blog = await _blogRepository.GetByIdAsync(blogId);

        blog.BlogImages.Remove(BlogImage);
        await _blogRepository.SaveAsync();
        return new ResultDto("successfully");
    }
}
