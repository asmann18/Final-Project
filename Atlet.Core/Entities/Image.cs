using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities;

public class Image:BaseAuditableEntity,IEntity
{
    public Image(string path)
    {
        Path = path;
    }
    public Image()
    {
        
    }
    public string Path { get; set; }
    public string Alt { get; set; } = "img";
}
