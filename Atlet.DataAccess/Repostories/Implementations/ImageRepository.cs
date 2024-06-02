

namespace Atlet.DataAccess.Repostories.Implementations;

public class ImageRepository:Repository<Image>,IImageRepository
{
	public ImageRepository(AppDbContext context):base(context)
	{

	}
}
