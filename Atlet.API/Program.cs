using Atlet.Business.Mappers.E_Commerce;
using Atlet.Business.Services.Implementations.E_Commerce;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.DataAccess.Contexts;
using Atlet.DataAccess.Repostories.Implementations;
using Atlet.DataAccess.Repostories.Implementations.Blogs;
using Atlet.DataAccess.Repostories.Implementations.E_Commerce;
using Atlet.DataAccess.Repostories.Implementations.Moves;
using Atlet.DataAccess.Repostories.Interfaces;
using Atlet.DataAccess.Repostories.Interfaces.Blogs;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.Moves; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); 


builder.Services.AddControllers().AddNewtonsoftJson(opt=>opt.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")); 
});



//Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IAromaRepository, AromaRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IImageRepository, ImageRepository>();

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();

builder.Services.AddScoped<IMoveRepository, MoveRepository>();
builder.Services.AddScoped<IPartRepository, PartRepository>();

//Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAromaService, AromaService>();
builder.Services.AddScoped<ICommentService, CommentService>();


builder.Services.AddAutoMapper(typeof(ProductAutoMapper). Assembly);




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
