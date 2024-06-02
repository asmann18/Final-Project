using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.DTOs.Moves.MoveDtos;

namespace Atlet.Business.Services.Interfaces.Moves;

public interface IMoveService
{
    Task<DataResultDto<List<MoveGetDto>>> GetAllMovesAsync(string? search);
    Task<DataResultDto<MoveGetDto>> GetMoveByIdAsync(int Id);
    Task<ResultDto> CreateMoveAsync(MovePostDto movePostDto);
    Task<ResultDto> UpdateMoveAsync(MovePutDto movePutDto);
    Task<ResultDto> DeleteMoveAsync(int Id);
}
