using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.AromaDtos;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;

namespace Atlet.Business.Services.Interfaces.E_Commerce;

public interface IAromaService
{

    Task<DataResultDto<List<AromaGetDto>>> GetAllAromasAsync(string? search);
    Task<DataResultDto<AromaGetDto>> GetAromaByIdAsync(int Id);
    Task<ResultDto> CreateAromaAsync(AromaPostDto AromaPostDto);
    Task<ResultDto> UpdateAromaAsync(AromaPutDto AromaPutDto);
    Task<ResultDto> DeleteAromaAsync(int Id);
    Task<DataResultDto<List<ProductRelationDto>>> GetAllProductsAsync(int Id);
}
