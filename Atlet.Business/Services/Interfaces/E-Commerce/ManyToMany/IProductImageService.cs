using Atlet.Core.Entities.E_Commerce.ManyToMany;

namespace Atlet.Business.Services.Interfaces.E_Commerce.ManyToMany
{
    public interface IProductImageService
    {
        Task<List<ProductImage>> GetProductImageUrlsByIdAsync(int ProductID);
        
      

        
    }
}
