using Atlet.Business.DTOs.Common;
using Atlet.Core.Entities.E_Commerce;
using Atlet.Core.Entities.Moves;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.Services.Interfaces;

public interface IImageService
{
    Task<List<string>>GetProductImageUrlsByIdAsync(int ProductID);
    Task<string> GetBrandImageUrlByIdasync(Brand brand);

    Task<List<string>> GetBlogImageUrlsByIdasync(int BlogId);

    Task<List<string>> GetMoveImageUrlsByIdasync(int MoveId);
    Task<string> GetPartImageUrlByIdasync(Part part);

    Task CreateProductImages(int productId,IFormFile[] images);
    Task DeleteProductImages(int productId);
    Task UpdateProductImages(int productId, IFormFile[] images);




    Task CreateBlogImages(int blogId,IFormFile[] images);
    Task DeleteBlogImages(int blogId);
    Task UpdateBlogImages(int blogId, IFormFile[] images);
    Task CreateMoveImages(int moveId,IFormFile[] images);
    Task DeleteMoveImages(int moveId);
    Task UpdateMoveImages(int moveId, IFormFile[] images);
    Task<int> CreateImage(IFormFile img);
    Task<ResultDto> DeleteImage(int imageId);
    Task<int> UpdateImage(int imageId, IFormFile img);


    
}
