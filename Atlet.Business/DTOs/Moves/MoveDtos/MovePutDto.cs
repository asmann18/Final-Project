using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.Moves.ManyToMany;
using Atlet.Core.Entities.Moves;

namespace Atlet.Business.DTOs.Moves.MoveDtos;

public class MovePutDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public Part part { get; set; }
    public ICollection<MoveImage> MoveImages { get; init; } = new List<MoveImage>();
}
