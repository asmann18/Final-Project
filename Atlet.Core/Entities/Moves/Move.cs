using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;
using Atlet.Core.Entities.Moves.ManyToMany;

namespace Atlet.Core.Entities.Moves;

public class Move:BaseAuditableEntity,IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PartId { get; set; }
    public Part Part { get; set; }
    public ICollection<MoveImage>  MoveImages { get; set; }=new List<MoveImage>();
}
