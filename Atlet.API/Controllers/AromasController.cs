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

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllAromas([FromQuery] string? search)
    {
        return Ok(await _aromaService.GetAllAromasAsync(search));
    }
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetAllProductsByAromaId([FromRoute] int id)
    {
        return Ok(await _aromaService.GetAllProductsAsync(id));
    }
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetBlogCategoryById([FromRoute] int id)
    {
        return Ok(await _aromaService.GetAromaByIdAsync(id));
    }



    [HttpPost("[action]")]
    public async Task<IActionResult> CreateAroma([FromBody] AromaPostDto aromaPostDto)
    {
        return Ok(await _aromaService.CreateAromaAsync(aromaPostDto));
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateAroma([FromBody]AromaPutDto aromaPutDto)
    {
        return Ok(await _aromaService.UpdateAromaAsync(aromaPutDto));   
    }
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteAroma([FromRoute]int id)
    {
        return Ok(await _aromaService.DeleteAromaAsync(id));
    }
    
}
