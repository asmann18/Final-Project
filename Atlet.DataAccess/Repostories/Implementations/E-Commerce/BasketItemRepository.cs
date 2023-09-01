namespace Atlet.DataAccess.Repostories.Implementations.E_Commerce;

public class BasketItemRepository:Repository<BasketItem>,IBasketItemRepository
{
    public BasketItemRepository(AppDbContext context) : base(context)
    {

    }
}
