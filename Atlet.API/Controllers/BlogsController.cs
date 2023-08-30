using Atlet.Business.DTOs.Blogs.BlogDtos;
using Atlet.Business.Services.Implementations.Blogs;
using Atlet.Business.Services.Interfaces.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAllBlog([FromQuery]string? search)
    {
        return Ok(await _blogService.GetAllBlogsAsync(search));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogCategoryById([FromRoute] int id)
    {
        return Ok(await _blogService.GetBlogByIdAsync(id));
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateBlog([FromBody]BlogPostDto blogPostDto)
    {
        return Ok(await _blogService.CreateBlogAsync(blogPostDto));
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateBlog([FromBody]BlogPutDto blogPutDto)
    {
        return Ok(await _blogService.UpdateBlogAsync(blogPutDto));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog([FromRoute]int id)
    {
        return Ok(await _blogService.DeleteBlogAsync(id));
    }
    
}
