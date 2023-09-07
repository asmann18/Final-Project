using Atlet.Business.Services.Interfaces.ManyToMany;
using Atlet.Core.Entities.E_Commerce.ManyToMany;
using Atlet.DataAccess.Repostories.Implementations.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.ManyToMany
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;
        public ProductImageService(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<int> CreateProductImage(int ProductId, int imageId)
        {
            ProductImage productImage = new ProductImage(ProductId, imageId);
            await _productImageRepository.CreateAsync(productImage);
            return productImage.Id;
        }
        public async Task DeleteProductImages(int ProductId)
        {
            var images=await GetProductImageUrlsByIdAsync(ProductId);
            foreach (var image in images)
            {
                _productImageRepository.Delete(image);

            }
            await _productImageRepository.SaveAsync();
        }
        public async Task<List<ProductImage>> GetProductImageUrlsByIdAsync(int ProductID)
        {


            var productImages = await _productImageRepository.GetFiltered(i => i.ProductId == ProductID).ToListAsync();

            return productImages;
        }
    }
}
