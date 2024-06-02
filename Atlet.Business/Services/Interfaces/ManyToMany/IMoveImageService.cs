using Atlet.Core.Entities.Moves.ManyToMany;

namespace Atlet.Business.Services.Interfaces.ManyToMany;

public interface IMoveImageService
{
    Task<List<MoveImage>> GetMoveImageUrlsByIdAsync(int MoveId);
    Task DeleteMoveImages(int MoveId);
    Task<int> CreateMoveImage(int MoveId, int imageId);


}
