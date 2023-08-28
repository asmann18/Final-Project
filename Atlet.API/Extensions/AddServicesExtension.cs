using Atlet.Business.Mappers.E_Commerce;
using Atlet.Business.Services.Implementations.E_Commerce;
using Atlet.Business.Services.Interfaces.E_Commerce;

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


        services.AddAutoMapper(typeof(ProductAutoMapper).Assembly);
        return services;
    }
}
