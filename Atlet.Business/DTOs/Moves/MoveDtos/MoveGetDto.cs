using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.Moves;
using Atlet.Core.Entities.Moves.ManyToMany;

namespace Atlet.Business.DTOs.Moves.MoveDtos;

public class MoveGetDto:IDto
{

    public string Name { get; init; }
    public string Description { get; init; }
    public Part part { get; set; }
    public ICollection<MoveImage> MoveImages { get; init; } = new List<MoveImage>();
}
