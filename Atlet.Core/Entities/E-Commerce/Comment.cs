using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;
using Atlet.Core.Entities.Identity;

namespace Atlet.Core.Entities.E_Commerce;

public class Comment:BaseAuditableEntity,IEntity
{
    public string Text { get; set; }
    public int Rating { get; set; }

    public string AppUserID { get; set; }
    public AppUser User { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int? ParentId { get; set; }
    public Comment? Parent { get; set; }
}
