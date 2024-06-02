namespace Atlet.DataAccess.Repostories.Implementations.E_Commerce;

public class BrandRepository:Repository<Brand>,IBrandRepository
{
	public BrandRepository(AppDbContext context) : base(context)
    {

    }
}
