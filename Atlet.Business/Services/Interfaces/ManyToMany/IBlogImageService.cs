using Atlet.Core.Entities.Blogs.ManyToMany;

namespace Atlet.Business.Services.Interfaces.ManyToMany;

public interface IBlogImageService
{
    Task<List<BlogImage>> GetBlogImageUrlsByIdAsync(int BlogId);
    Task DeleteBlogImages(int BlogId);
    Task<BlogImage> CreateBlogImage(int BlogId, int imageId);


}
