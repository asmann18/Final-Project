using Atlet.Business.Services.Interfaces.ManyToMany;
using Atlet.Core.Entities.Blogs.ManyToMany;
using Atlet.DataAccess.Repostories.Implementations.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.ManyToMany;

public class BlogImageService : IBlogImageService
{
    private readonly IBlogImageRepository _blogImageRepository;

    public BlogImageService(IBlogImageRepository blogImageRepository)
    {
        _blogImageRepository = blogImageRepository;
    }

    public async Task<int> CreateBlogImage(int BlogId, int imageId)
    {
        BlogImage image = new BlogImage(BlogId, imageId);
        await _blogImageRepository.CreateAsync(image);
        return image.Id;
    }
    public async Task DeleteBlogImages(int MoveId)
    {
        var images = await GetBlogImageUrlsByIdAsync(MoveId);
        foreach (var image in images)
        {
            _blogImageRepository.Delete(image);

        }
    }

    public async Task<List<BlogImage>> GetBlogImageUrlsByIdAsync(int BlogId)
    {
        var blogImages = await _blogImageRepository.GetFiltered(i => i.BlogId == BlogId).ToListAsync();
        return blogImages;
    }
}
