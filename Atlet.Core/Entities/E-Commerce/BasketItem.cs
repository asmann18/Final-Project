using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.E_Commerce;

public class BasketItem:BaseEntity,IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Count { get; set; }
    public int BasketId { get; set; }
    public Basket Basket { get; set; }
}
