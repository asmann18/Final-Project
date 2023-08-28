using Atlet.Business.DTOs.ImageDtos;
using Atlet.Core.Entities.E_Commerce;
using Atlet.Core.Entities.Moves;

namespace Atlet.Business.Services.Interfaces;

public interface IImageService
{
    Task<List<string>>GetProductImageUrlsByIdAsync(int ProductID);
    Task<string> GetBrandImageUrlByIdasync(Brand brand);

    Task<List<string>> GetBlogImageUrlsByIdasync(int BlogId);

    Task<List<string>> GetMoveImageUrlsByIdasync(int MoveId);
    Task<string> GetPartImageUrlByIdasync(Part part);


    
}
