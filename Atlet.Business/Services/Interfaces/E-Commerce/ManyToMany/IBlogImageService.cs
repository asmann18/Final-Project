using Atlet.Core.Entities.Blogs.ManyToMany;

namespace Atlet.Business.Services.Interfaces.E_Commerce.ManyToMany;

public interface IBlogImageService
{
    Task<List<BlogImage>> GetBlogImageUrlsByIdAsync(int BlogId);

}
