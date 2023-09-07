using Atlet.Business.Services.Interfaces.ManyToMany;
using Atlet.Core.Entities.Moves.ManyToMany;
using Atlet.DataAccess.Repostories.Implementations.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.ManyToMany;

public class MoveImageService : IMoveImageService
{
    private readonly IMoveImageRepository _moveImageRepository;

    public MoveImageService(IMoveImageRepository moveImageRepository)
    {
        _moveImageRepository = moveImageRepository;
    }

    public async Task<int> CreateMoveImage(int MoveId, int imageId)
    {
        MoveImage moveImage = new MoveImage(MoveId, imageId);
        await _moveImageRepository.CreateAsync(moveImage);
        return moveImage.Id;
    }
    public async Task DeleteMoveImages(int MoveId)
    {
        var images = await GetMoveImageUrlsByIdAsync(MoveId);
        foreach (var image in images)
        {
            _moveImageRepository.Delete(image);
        }

       await _moveImageRepository.SaveAsync();
    }
    public async Task<List<MoveImage>> GetMoveImageUrlsByIdAsync(int MoveId)
    {
        var MoveImages = await _moveImageRepository.GetFiltered(i => i.MoveId == MoveId).ToListAsync();
        return MoveImages;
    }
}
