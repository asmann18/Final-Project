using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.Move;

public class Part:BaseEntity,IEntity
{
    public string Name { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
    public ICollection<Move> Moves { get; set; } = new List<Move>();
}
