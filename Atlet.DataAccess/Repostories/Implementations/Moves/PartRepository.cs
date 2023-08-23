using Atlet.Core.Entities.Moves;
using Atlet.DataAccess.Contexts;
using Atlet.DataAccess.Repostories.Interfaces.Moves;

namespace Atlet.DataAccess.Repostories.Implementations.Moves;

public class PartRepository:Repository<Part>,IPartRepository
{
	public PartRepository(AppDbContext context):base(context)
	{
			
	}
}
