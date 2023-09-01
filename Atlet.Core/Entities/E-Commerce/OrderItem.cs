using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;
using Atlet.Core.Entities.Identity;

namespace Atlet.Core.Entities.E_Commerce;

public class OrderItem:BaseAuditableEntity,IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public decimal staticPrice { get; set; }
    public int Count { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
}
