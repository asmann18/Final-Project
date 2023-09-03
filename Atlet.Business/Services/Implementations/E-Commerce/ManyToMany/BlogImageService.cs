using Atlet.Business.Services.Interfaces.E_Commerce.ManyToMany;
using Atlet.Core.Entities.Blogs.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.E_Commerce.ManyToMany;

public class BlogImageService : IBlogImageService
{
    private readonly IBlogImageRepository _blogImageRepository;

    public BlogImageService(IBlogImageRepository blogImageRepository)
    {
        _blogImageRepository = blogImageRepository;
    }

    public async Task<List<BlogImage>> GetBlogImageUrlsByIdAsync(int BlogId)
    {
        var blogImages = await _blogImageRepository.GetFiltered(i => i.BlogId == BlogId).ToListAsync();
        return blogImages;
    }
}
