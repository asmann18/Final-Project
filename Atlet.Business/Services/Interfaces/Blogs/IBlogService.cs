using Atlet.Business.DTOs.Blogs.BlogDtos;
using Atlet.Business.DTOs.Common;
using Atlet.Core.Entities.Blogs.ManyToMany;

namespace Atlet.Business.Services.Interfaces.Blogs;

public interface IBlogService
{
    Task<DataResultDto<List<BlogGetDto>>> GetAllBlogsAsync(string? search);
    Task<DataResultDto<BlogGetDto>> GetBlogByIdAsync(int Id);
    Task<ResultDto> CreateBlogAsync(BlogPostDto blogPostDto);
    Task<ResultDto> UpdateBlogAsync(BlogPutDto blogPutDto);
    Task<ResultDto> DeleteBlogAsync(int Id);


    Task<ResultDto> AddBlogImages(int blogId,BlogImage BlogImage);
    Task<ResultDto> RemoveBlogImages(int blogId,BlogImage BlogImage);
}
