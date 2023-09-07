using Atlet.Business.DTOs.Common;
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

    Task CreateProductImages(int productId,string[] paths);
    Task DeleteProductImages(int productId);
    Task UpdateProductImages(int productId, string[] paths);




    Task CreateBlogImages(int blogId,string[] paths);
    Task DeleteBlogImages(int blogId);
    Task UpdateBlogImages(int blogId, string[] paths);
    Task CreateMoveImages(int moveId,string[] paths);
    Task DeleteMoveImages(int moveId);
    Task UpdateMoveImages(int moveId, string[] paths);
    Task<int> CreateImage(string path);
    Task<ResultDto> DeleteImage(int imageId);
    Task<int> UpdateImage(int imageId, string path);


    
}
