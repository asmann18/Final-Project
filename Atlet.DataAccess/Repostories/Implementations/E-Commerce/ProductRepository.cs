namespace Atlet.DataAccess.Repostories.Implementations.E_Commerce;

public class ProductRepository:Repository<Product>,IProductRepository
{
	public ProductRepository(AppDbContext context):base(context)
	{

	}

}
