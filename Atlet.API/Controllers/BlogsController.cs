using Atlet.Business.DTOs.Blogs.BlogDtos;
using Atlet.Business.Services.Implementations.Blogs;
using Atlet.Business.Services.Interfaces.Blogs;
using Microsoft.AspNetCore.Authorization;
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
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllBlog([FromQuery]string? search)
    {
        return Ok(await _blogService.GetAllBlogsAsync(search));
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetBlogById([FromRoute] int id)
    {
        return Ok(await _blogService.GetBlogByIdAsync(id));
    }

    [HttpPost("[action]")]
    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> CreateBlog([FromForm]BlogPostDto blogPostDto)
    {
        return Ok(await _blogService.CreateBlogAsync(blogPostDto));
    }

    [HttpPut("[action]")]
    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> UpdateBlog([FromForm]BlogPutDto blogPutDto)
    {
        return Ok(await _blogService.UpdateBlogAsync(blogPutDto));
    }
    [HttpDelete("[action]/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteBlog([FromRoute]int id)
    {
        return Ok(await _blogService.DeleteBlogAsync(id));
    }
    
}
