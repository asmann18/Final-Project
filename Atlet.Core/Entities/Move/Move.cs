using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.Move;

public class Move:BaseAuditableEntity,IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PartId { get; set; }
    public Image Image { get; set; }
}
