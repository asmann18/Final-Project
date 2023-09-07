using Atlet.Core.Entities.E_Commerce.ManyToMany;

namespace Atlet.Business.Services.Interfaces.ManyToMany
{
    public interface IProductImageService
    {
        Task<List<ProductImage>> GetProductImageUrlsByIdAsync(int ProductID);
        Task DeleteProductImages(int ProductId);
        Task<int> CreateProductImage(int ProductId, int imageId);
    }
}
