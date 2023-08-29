using Atlet.Business.DTOs.E_Commerce.BrandDtos;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllProducts([FromQuery]string? search)
    {
        return Ok(await _brandService.GetAllBrandsAsync(search));
    }
    [HttpPost("")]
    public async Task<IActionResult> CreateBrand([FromBody]BrandPostDto brandPostDto)
    {
        return Ok(await _brandService.CreateBrandAsync(brandPostDto));
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBrand([FromBody]BrandPutDto brandPutDto)
    {
        return Ok(await _brandService.UpdateBrandAsync(brandPutDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand([FromRoute]int id)
    {
        return Ok(await _brandService.DeleteBrandAsync(id));
    }

    [HttpGet("Products/{id}")]
    public async Task<IActionResult> GetAllProductsInBrandByBrandId([FromRoute]int id)
    {
        return Ok(await _brandService.GetAllProductsInBrandByBrandIdAsync(id));
    }
}
