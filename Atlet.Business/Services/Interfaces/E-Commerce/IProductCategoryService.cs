using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.ProductCategoryDtos;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;

namespace Atlet.Business.Services.Interfaces.E_Commerce;

public interface IProductCategoryService
{
    Task<DataResultDto<List<ProductCategoryGetDto>>> GetAllCategoriesAsync(string? search);
    Task<DataResultDto<ProductCategoryGetDto>> GetCategoryByIdAsync(int Id);
    Task<DataResultDto<List<ProductRelationDto>>> GetAllProductsInCategoryByIdAsync(int id);
    Task<ResultDto> CreateCategoryAsync(ProductCategoryPostDto productCategoryPostDto);
    Task<ResultDto> UpdateCategoryAsync(ProductCategoryPutDto productCategoryPutDto);
    Task<ResultDto> DeleteCategoryAsync(int Id);
}
