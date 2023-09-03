using Atlet.Business.Services.Interfaces.E_Commerce.ManyToMany;
using Atlet.Core.Entities.E_Commerce.ManyToMany;
using Atlet.DataAccess.Repostories.Implementations.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.E_Commerce.ManyToMany
{
    internal class ProductImageService : IProductImageService
    {
        private readonly ProductImageRepository _productImageRepository;
        public ProductImageService(ProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<List<ProductImage>> GetProductImageUrlsByIdAsync(int ProductID)
        {


            var productImages =await _productImageRepository.GetFiltered(i => i.ProductId == ProductID).ToListAsync();

            return productImages;
        }
    }
}
