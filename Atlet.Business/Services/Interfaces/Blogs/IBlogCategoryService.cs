using Atlet.Business.DTOs.Blogs.BlogCategoryDtos;
using Atlet.Business.DTOs.Blogs.BlogDtos;
using Atlet.Business.DTOs.Common;

namespace Atlet.Business.Services.Interfaces.Blogs;

public interface IBlogCategoryService
{
    Task<DataResultDto<List<BlogCategoryGetDto>>> GetAllBlogCategorysAsync(string? search);
    Task<DataResultDto<BlogCategoryGetDto>> GetBlogCategoryByIdAsync(int Id);
    Task<ResultDto> CreateBlogCategoryAsync(BlogCategoryPostDto blogCategoryPostDto);
    Task<ResultDto> UpdateBlogCategoryAsync(BlogCategoryPutDto blogCategoryPutDto);
    Task<ResultDto> DeleteBlogCategoryAsync(int Id);
    Task<DataResultDto<List<BlogGetDto>>> GetAllBlogsByCategoryId(int id);
    
}
