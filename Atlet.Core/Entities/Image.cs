using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities;

public class Image:BaseAuditableEntity,IEntity
{
    public string Path { get; set; }
    public string Alt { get; set; } = "img";
}
