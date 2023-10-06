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

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllProducts([FromQuery]string? search)
    {
        return Ok(await _brandService.GetAllBrandsAsync(search));
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetAllProductsInBrandByBrandId([FromRoute] int id)
    {
        return Ok(await _brandService.GetAllProductsInBrandByBrandIdAsync(id));
    }
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetBlogCategoryById([FromRoute] int id)
    {
        return Ok(await _brandService.GetBrandByIdAsync(id));
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> CreateBrand([FromForm]BrandPostDto brandPostDto)
    {
        return Ok(await _brandService.CreateBrandAsync(brandPostDto));
    }


    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateBrand([FromForm]BrandPutDto brandPutDto)
    {
        return Ok(await _brandService.UpdateBrandAsync(brandPutDto));
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteBrand([FromRoute]int id)
    {
        return Ok(await _brandService.DeleteBrandAsync(id));
    }

    
}
