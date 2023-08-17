using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.Product;

namespace Atlet.Business.Services.Interfaces.E_Commerce
{
    public interface IProductService
    {
        Task<DataResultDto<List<ProductGetDto>>> GetAllProductsAsync(string? search);
        Task<DataResultDto<ProductGetDto>> GetProductByIdAsync(int Id);
        Task<ResultDto> CreateProductAsync(ProductPostDto productPostDto);
        Task<ResultDto> UpdateProductAsync(ProductPutDto productPutDto);
        Task<ResultDto> DeleteProductAsync(int Id);
    }
}
