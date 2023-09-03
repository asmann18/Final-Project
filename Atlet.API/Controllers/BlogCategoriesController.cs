using Atlet.Business.DTOs.Blogs.BlogCategoryDtos;
using Atlet.Business.Services.Interfaces.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogCategoriesController : ControllerBase
{
    private readonly IBlogCategoryService _blogCategoryService;

    public BlogCategoriesController(IBlogCategoryService blogCategoryService)
    {
        _blogCategoryService = blogCategoryService;
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllBlogCategories([FromQuery] string? search)
    {
         return Ok(await _blogCategoryService.GetAllBlogCategorysAsync(search));
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetAllBlogByCategoryId([FromRoute] int id)
    {
        return Ok(await _blogCategoryService.GetAllBlogsByCategoryId(id));
    }
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetBlogCategoryById([FromRoute] int id)
    {
        return Ok(await _blogCategoryService.GetBlogCategoryByIdAsync(id));
    }



    [HttpPost("[action]")]
    public async Task<IActionResult> CreateBlogCategory([FromBody]BlogCategoryPostDto blogCategoryPostDto)
    {
        return Ok(await _blogCategoryService.CreateBlogCategoryAsync(blogCategoryPostDto));
    }
    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateBlogCategory([FromBody]BlogCategoryPutDto blogCategoryPutDto)
    {
        return Ok(await _blogCategoryService.UpdateBlogCategoryAsync(blogCategoryPutDto));
    }
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteBlogCategory([FromRoute]int id)
    {
        return Ok(await _blogCategoryService.DeleteBlogCategoryAsync(id));
    }

}
