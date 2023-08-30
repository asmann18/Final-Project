using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.Moves.MoveDtos;

namespace Atlet.Business.DTOs.Moves.PartDtos;

public class PartGetDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int ImageId { get; init; }
    public ICollection<MoveRelationDto> Moves { get; init; } = new List<MoveRelationDto>();
}
