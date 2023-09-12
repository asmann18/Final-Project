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
        [Authorize]
        public async Task<IActionResult> GetAllProducts([FromQuery] string? search)
        {

            return Ok(await _productCategoryService.GetAllCategoriesAsync(search));

        }
        [HttpGet("[action]/{CategoryId}")]
        public async Task<IActionResult> GetAllProductsInCategoryById([FromRoute] int CategoryId)
        {
            return Ok(await _productCategoryService.GetAllProductsInCategoryByIdAsync(CategoryId));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] int id)
        {


            return Ok(await _productCategoryService.GetCategoryByIdAsync(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCategoryPostDto productCategoryPostDto)
        {
            return Ok(await _productCategoryService.CreateCategoryAsync(productCategoryPostDto));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> PutProductById([FromBody] ProductCategoryPutDto productCategoryPutDto)
        {
            return Ok(await _productCategoryService.UpdateCategoryAsync(productCategoryPutDto));
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteProductById([FromRoute] int id)
        {
            return Ok(await _productCategoryService.DeleteCategoryAsync(id));
        }
    }
}
