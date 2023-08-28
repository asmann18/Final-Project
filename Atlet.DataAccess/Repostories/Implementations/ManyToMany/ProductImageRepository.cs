using Atlet.Core.Entities.E_Commerce.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.ManyToMany;

namespace Atlet.DataAccess.Repostories.Implementations.ManyToMany;

public class ProductImageRepository:Repository<ProductImage>,IProductImageRepository
{
    public ProductImageRepository(AppDbContext context):base(context)
    {
            
    }
}
