namespace Atlet.DataAccess.Repostories.Implementations.E_Commerce;

public class OrderItemRepository:Repository<OrderItem>,IOrderItemRepository
{
    public OrderItemRepository(AppDbContext context) : base(context)
    {

    }
}
