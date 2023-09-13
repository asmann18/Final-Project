using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;

namespace Atlet.Business.Services.Interfaces.E_Commerce
{
    public interface IProductService
    {
        Task<DataResultDto<List<ProductGetDto>>> GetAllProductsAsync(string? search);
        Task<DataResultDto<ProductGetDto>> GetProductByIdAsync(int Id);
        Task<ResultDto> CreateProductAsync(ProductPostDto productPostDto);
        Task<ResultDto> UpdateProductAsync(ProductPutDto productPutDto);
        Task<ResultDto> UpdateProductRatingAsync(ProductRatingPutDto productRatingPutDto);
        Task<ResultDto> DeleteProductAsync(int Id);
        Task<DataResultDto<List<ProductGetDto>>> GetFilteredProducts(ProductFilteredDtos filter);
    }
}
