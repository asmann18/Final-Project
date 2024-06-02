using Atlet.Core.Entities.Moves;
using Atlet.DataAccess.Contexts;
using Atlet.DataAccess.Repostories.Interfaces.Moves;

namespace Atlet.DataAccess.Repostories.Implementations.Moves;

public class MoveRepository:Repository<Move>,IMoveRepository
{
	public MoveRepository(AppDbContext context):base(context)
	{

	}
}
