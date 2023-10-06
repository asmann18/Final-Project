using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.E_Commerce.ManyToMany;

public class Order:BaseAuditableEntity,IEntity
{
    public Order()
    {
        
    }
    public Order(List<BasketItem> basketItems)
    {
        BasketItems=basketItems;
        IsStatus = false;
    }
    public bool? IsStatus { get; set; } = false;
    public List<BasketItem> BasketItems = new List<BasketItem>();

}
