using Atlet.DataAccess.Repostories.Implementations.Blogs;
using Atlet.DataAccess.Repostories.Implementations.E_Commerce;
using Atlet.DataAccess.Repostories.Implementations.Moves;
using Atlet.DataAccess.Repostories.Implementations;
using Atlet.DataAccess.Repostories.Interfaces.Blogs;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.Moves;
using Atlet.DataAccess.Repostories.Interfaces;
using Atlet.DataAccess.Repostories.Interfaces.ManyToMany;
using Atlet.DataAccess.Repostories.Implementations.ManyToMany;

namespace Atlet.API.Extensions;

public static class AddRepositoriesExtension
{
    public static IServiceCollection AddRepositoriesService(this IServiceCollection services)
    {
        services.AddScoped<IProductImageRepository, ProductImageRepository>();
        services.AddScoped<IBlogImageRepository, BlogImageRepository>();
        services.AddScoped<IMoveImageRepository, MoveImageRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IAromaRepository, AromaRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IBasketItemRepository, BasketItemRepository>();


        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();

        services.AddScoped<IMoveRepository, MoveRepository>();
        services.AddScoped<IPartRepository, PartRepository>();



        return services;
    }
}
