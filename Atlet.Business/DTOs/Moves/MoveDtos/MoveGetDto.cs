using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.Moves.PartDtos;

namespace Atlet.Business.DTOs.Moves.MoveDtos;

public class MoveGetDto:IDto
{

    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public PartRelationDto Part { get; set; }
    public ICollection<int> MoveImageIds { get; init; } = new List<int>();
}
