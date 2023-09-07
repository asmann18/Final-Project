using Atlet.API.Extensions;
using Atlet.Business.Services.Implementations.ManyToMany;
using Atlet.Business.Services.Implementations;
using Atlet.Business.Services.Interfaces.ManyToMany;
using Atlet.Business.Services.Interfaces;
using Atlet.Business.Validators.E_CommerceValidators;
using Atlet.Core.Entities.Identity;
using Atlet.DataAccess.Contexts;
using Atlet.DataAccess.Interceptors;
using Atlet.DataAccess.Repostories.Implementations.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.ManyToMany;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().AddNewtonsoftJson(opt=>opt.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining(typeof(ProductPostDtoValidators)));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")); 
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;

    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//Repositories
//builder.Services.AddScoped<IProductImageService, ProductImageService>();
//builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();

builder.Services.AddServicesService();
builder.Services.AddRepositoriesService();

//Services

//Interceptor
builder.Services.AddScoped<BaseAuditableInterceptor>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.AddExceptionHandlerService();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
