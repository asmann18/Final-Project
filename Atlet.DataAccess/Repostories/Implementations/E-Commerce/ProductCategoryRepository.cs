namespace Atlet.DataAccess.Repostories.Implementations.E_Commerce;

public class ProductCategoryRepository:Repository<ProductCategory>,IProductCategoryRepository
{
	public ProductCategoryRepository(AppDbContext context):base(context)
	{

	}
}
