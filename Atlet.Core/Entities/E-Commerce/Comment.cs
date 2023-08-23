using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.E_Commerce;

public class Comment:BaseAuditableEntity,IEntity
{
    public string Text { get; set; }
    public int Rating { get; set; }
    //--------------->>User elave olunandan sonra
    //public int UserID { get; set; }
    //public User User            //configurations duzelt
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int? ParentId { get; set; }
    public Comment? Parent { get; set; }
}
