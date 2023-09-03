using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.BrandDtos;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;

namespace Atlet.Business.Services.Interfaces.E_Commerce;

public interface IBrandService
{
    Task<DataResultDto<List<BrandGetDto>>> GetAllBrandsAsync(string? search);
    Task<DataResultDto<BrandGetDto>> GetBrandByIdAsync(int Id);
    Task<ResultDto> CreateBrandAsync(BrandPostDto brandPostDto);
    Task<ResultDto> UpdateBrandAsync(BrandPutDto brandPutDto);
    Task<ResultDto> DeleteBrandAsync(int Id);
    Task<DataResultDto<List<ProductRelationDto>>>
        GetAllProductsInBrandByBrandIdAsync(int Id);
}
