using Atlet.Business.Mappers.E_Commerce;
using Atlet.Business.Services.Implementations.Blogs;
using Atlet.Business.Services.Implementations.E_Commerce;
using Atlet.Business.Services.Implementations.Moves;
using Atlet.Business.Services.Interfaces.Blogs;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Business.Services.Interfaces.Moves;

namespace Atlet.API.Extensions;

public static class AddServicesExtension
{
    public static IServiceCollection AddServicesService(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IAromaService, AromaService>();
        services.AddScoped<ICommentService, CommentService>();

        services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<IBlogCategoryService, BlogCategoryService>();

        services.AddScoped<IMoveService, MoveService>();
        services.AddScoped<IPartService, PartService>();


        services.AddAutoMapper(typeof(ProductAutoMapper).Assembly);
        return services;
    }
}
