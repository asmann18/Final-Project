using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllProducts([FromQuery] string? search) { 
        
            return Ok(await _productService.GetAllProductsAsync(search)                );
        
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute]int id) {


            return Ok(await _productService.GetProductByIdAsync(id));
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateProduct([FromBody]ProductPostDto productPostDto)
        {
            return Ok(await _productService.CreateProductAsync(productPostDto));
        }
        [HttpPut("")]
        public async Task<IActionResult> PutProductById([FromBody]ProductPutDto productPutDto)
        {
            return Ok(await _productService.UpdateProductAsync(productPutDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById([FromRoute]int id)
        {
            return Ok(await _productService.DeleteProductAsync(id));
        }
    }
}
