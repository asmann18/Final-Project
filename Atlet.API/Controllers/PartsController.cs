using Atlet.Business.DTOs.Moves.PartDtos;
using Atlet.Business.Services.Interfaces.Moves;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartsController : ControllerBase
{
    private readonly IPartService _partService;

    public PartsController(IPartService partService)
    {
        _partService = partService;
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAllParts([FromQuery] string? search)
    {
        return Ok(await _partService.GetAllPartsAsync(search));
    }

    [HttpGet("Moves/{id}")]
    public async Task<IActionResult> GetAllMovesByPartId([FromRoute] int id)
    {
        return Ok(await _partService.GetAllMovesByPartId(id));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogCategoryById([FromRoute] int id)
    {
        return Ok(await _partService.GetPartByIdAsync(id));
    }
    [HttpPost("")]
    public async Task<IActionResult> CreatePart([FromBody]PartPostDto partPostDto)
    {
        return Ok(await _partService.CreatePartAsync(partPostDto));
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdatePart([FromBody]PartPutDto partPutDto)
    {
        return Ok(await _partService.UpdatePartAsync(partPutDto));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePart([FromRoute]int id)
    {
        return Ok(await _partService.DeletePartAsync(id));
    }

    
}
