using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Moves.MoveDtos;

public class MoveRelationDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
}
