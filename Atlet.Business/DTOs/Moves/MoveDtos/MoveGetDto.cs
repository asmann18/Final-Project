using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.Moves.PartDtos;
using Atlet.Core.Entities.Common;

namespace Atlet.Business.DTOs.Moves.MoveDtos;

public class MoveGetDto:IDto
{

    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public PartRelationDto Part { get; set; }
    public List<string> MoveImagePaths { get; set; } = new List<string>();
    public DateTime ModifiedTime { get; set; }
    
}
