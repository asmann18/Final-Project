using Atlet.Business.DTOs.E_Commerce.AromaDtos;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AromasController : ControllerBase
{
    private readonly IAromaService _aromaService;

    public AromasController(IAromaService aromaService)
    {
        _aromaService = aromaService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllAroma([FromQuery] string? search)
    {
        return Ok(await _aromaService.GetAllAromasAsync(search));
    }
    [HttpGet("Products/{id}")]
    public async Task<IActionResult> GetAllProductsByAromaId([FromRoute] int id)
    {
        return Ok(await _aromaService.GetAllProductsAsync(id));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogCategoryById([FromRoute] int id)
    {
        return Ok(await _aromaService.GetAromaByIdAsync(id));
    }



    [HttpPost("")]
    public async Task<IActionResult> CreateAroma([FromBody] AromaPostDto aromaPostDto)
    {
        return Ok(await _aromaService.CreateAromaAsync(aromaPostDto));
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAroma([FromBody]AromaPutDto aromaPutDto)
    {
        return Ok(await _aromaService.UpdateAromaAsync(aromaPutDto));   
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAroma([FromRoute]int id)
    {
        return Ok(await _aromaService.DeleteAromaAsync(id));
    }
    
}
