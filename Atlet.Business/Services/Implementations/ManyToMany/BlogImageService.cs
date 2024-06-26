﻿using Atlet.Business.Services.Interfaces.Blogs;
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

    public async Task<BlogImage> CreateBlogImage(int BlogId, int imageId)
    {
        BlogImage image = new BlogImage(BlogId, imageId);
        
        await _blogImageRepository.CreateAsync(image);

        return image;
    }
    public async Task DeleteBlogImages(int blogID)
    {
        var images = await GetBlogImageUrlsByIdAsync(blogID);
        foreach (var image in images)
        {
            _blogImageRepository.Delete(image);
            

        }
        await _blogImageRepository.SaveAsync();
    }

    public async Task<List<BlogImage>> GetBlogImageUrlsByIdAsync(int BlogId)
    {
        var blogImages = await _blogImageRepository.GetFiltered(i => i.BlogId == BlogId).ToListAsync();
        return blogImages;
    }
}
