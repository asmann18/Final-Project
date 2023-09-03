using Atlet.Core.Entities.Moves.ManyToMany;

namespace Atlet.Business.Services.Interfaces.E_Commerce.ManyToMany;

public interface IMoveImageService
{
    Task<List<MoveImage>> GetMoveImageUrlsByIdAsync(int MoveId);

}
