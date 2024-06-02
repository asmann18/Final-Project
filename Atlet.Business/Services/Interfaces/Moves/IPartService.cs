using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.Moves.MoveDtos;
using Atlet.Business.DTOs.Moves.PartDtos;

namespace Atlet.Business.Services.Interfaces.Moves;

public  interface IPartService
{
    Task<DataResultDto<List<PartGetDto>>> GetAllPartsAsync(string? search);
    Task<DataResultDto<PartGetDto>> GetPartByIdAsync(int Id);
    Task<ResultDto> CreatePartAsync(PartPostDto partPostDto);
    Task<ResultDto> UpdatePartAsync(PartPutDto partPutDto);
    Task<ResultDto> DeletePartAsync(int Id);
    Task<DataResultDto<List<MoveGetDto>>> GetAllMovesByPartId(int id);
}
