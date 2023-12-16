using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.E_Commerce.ManyToMany;

public class Order : BaseAuditableEntity, IEntity
{
    public Order()
    {

    }
    public Order(List<BasketItem> basketItems)
    {
        BasketItems = basketItems;
        IsStatus = false;
        foreach (var item in basketItems)
        {
            TotalPrice += ((double)item.Product.Price * item.Count);
        }
    }
    public Order(List<BasketItem> basketItems, string location)
    {
        BasketItems = basketItems;
        isDelivery = true;
        Location = location;
        IsStatus = false;
        foreach (var item in basketItems)
        {
            TotalPrice += ((double)item.Product.Price*item.Count);
        }
        TotalPrice += 5; //with delivery
    }
    public bool? IsStatus { get; set; } = false;
    public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    public string AppUserId { get; set; }
    public bool isDelivery { get; set; } = false;
    public string? Location { get; set; }

    public double TotalPrice { get; set; } = 0;
}
