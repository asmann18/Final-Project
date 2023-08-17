namespace Atlet.DataAccess.Repostories.Implementations.E_Commerce;

public class AromaRepository:Repository<Aroma>,IAromaRepository
{
	public AromaRepository(AppDbContext context) : base(context)
    {

    }
}
