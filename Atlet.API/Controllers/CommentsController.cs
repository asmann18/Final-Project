using Atlet.Business.DTOs.E_Commerce.CommentDtos;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddComment([FromBody]CommentPostDto comment)
    {
        return Ok(await _commentService.CreateCommentAsync(comment));
    }
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteComment([FromRoute] int id)
    {
        return  Ok(await _commentService.DeleteCommentAsync(id));
    }
    [HttpGet("[action]/{ProductId}")]
    public async Task<IActionResult> GetComments([FromRoute]int ProductId)
    {
        return Ok(await _commentService.GetAllCommentsByProductIdAsync(ProductId));
    }
}
