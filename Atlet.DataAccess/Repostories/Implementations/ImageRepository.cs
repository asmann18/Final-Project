

namespace Atlet.DataAccess.Repostories.Implementations;

internal class ImageRepository:Repository<Image>,IImageRepository
{
	public ImageRepository(AppDbContext context):base(context)
	{

	}
}
