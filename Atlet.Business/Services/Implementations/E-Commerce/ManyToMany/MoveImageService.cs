using Atlet.Business.Services.Interfaces.E_Commerce.ManyToMany;
using Atlet.Core.Entities.Moves.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.E_Commerce.ManyToMany;

public class MoveImageService : IMoveImageService
{
    private readonly IMoveImageRepository _moveImageRepository;

    public MoveImageService(IMoveImageRepository moveImageRepository)
    {
        _moveImageRepository = moveImageRepository;
    }

    public async Task<List<MoveImage>> GetMoveImageUrlsByIdAsync(int MoveId)
    {
        var MoveImages =await _moveImageRepository.GetFiltered(i => i.MoveId == MoveId).ToListAsync();
        return MoveImages;
    }
}
