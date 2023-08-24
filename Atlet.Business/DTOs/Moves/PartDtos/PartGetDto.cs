using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.Moves;

namespace Atlet.Business.DTOs.Moves.PartDtos;

public class PartGetDto:IDto
{
    public string Name { get; init; }
    public int ImageId { get; init; }
    public ICollection<Move> Moves { get; init; } = new List<Move>();
}
