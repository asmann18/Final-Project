using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Member")]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetAllProducts([FromQuery] string? search) { 
        
            return Ok(await _productService.GetAllProductsAsync(search)                );
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetDiscountProducts()
        {
            return Ok(await _productService.GetDiscountProducts());
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetPopularProducts()
        {
            return Ok(await _productService.GetPopularProducts());
        }



        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute]int id) {


            return Ok(await _productService.GetProductByIdAsync(id));
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductPostDto productPostDto)
        {
            return Ok(await _productService.CreateProductAsync(productPostDto));
        }
        [HttpPut("[action]")]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> PutProductById([FromForm]ProductPutDto productPutDto)
        {
            return Ok(await _productService.UpdateProductAsync(productPutDto));
        }

        [HttpDelete("[action]/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProductById([FromRoute]int id)
        {
            return Ok(await _productService.DeleteProductAsync(id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> FilteredProducts([FromBody]ProductFilteredDtos productFilteredDtos)
        {
            return Ok(await _productService.GetFilteredProducts(productFilteredDtos));
        }
    }
}
