using Atlet.Business.DTOs.E_Commerce.ProductCategoryDtos;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoriesController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductCategories([FromQuery] string? search)
        {

            return Ok(await _productCategoryService.GetAllCategoriesAsync(search));

        }
        [HttpGet("[action]/{CategoryId}")]
        public async Task<IActionResult> GetAllProductsInCategoryById([FromRoute] int CategoryId)
        {
            return Ok(await _productCategoryService.GetAllProductsInCategoryByIdAsync(CategoryId));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductCategoryByIdAsync([FromRoute] int id)
        {


            return Ok(await _productCategoryService.GetCategoryByIdAsync(id));
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> CreateProductCategory([FromBody] ProductCategoryPostDto productCategoryPostDto)
        {
            return Ok(await _productCategoryService.CreateCategoryAsync(productCategoryPostDto));
        }
        [HttpPut("[action]")]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> PutProductCategoryById([FromBody] ProductCategoryPutDto productCategoryPutDto)
        {
            return Ok(await _productCategoryService.UpdateCategoryAsync(productCategoryPutDto));
        }

        [HttpDelete("[action]/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProductCategoryById([FromRoute] int id)
        {
            return Ok(await _productCategoryService.DeleteCategoryAsync(id));
        }
    }
}
