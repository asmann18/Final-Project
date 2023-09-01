namespace Atlet.DataAccess.Repostories.Implementations.E_Commerce;

public class BasketRepository:Repository<Basket>,IBasketRepository
{
    public BasketRepository(AppDbContext context):base(context)
    {
        
    }
}
