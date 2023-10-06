using Atlet.Core.Entities.E_Commerce.ManyToMany;

namespace Atlet.DataAccess.Repostories.Implementations.E_Commerce;

public class OrderRepository:Repository<Order>,IOrderRepository
{
    public OrderRepository(AppDbContext context):base(context)
    {
        
    }
}
