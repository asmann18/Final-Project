using Atlet.Core.Entities.Moves.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.ManyToMany;

namespace Atlet.DataAccess.Repostories.Implementations.ManyToMany;

public class MoveImageRepository:Repository<MoveImage>,IMoveImageRepository
{
    public MoveImageRepository(AppDbContext context):base(context)
    {
        
    }
}
