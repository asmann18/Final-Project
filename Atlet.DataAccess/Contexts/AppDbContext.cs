using Atlet.Core.Entities.Blogs.ManyToMany;
using Atlet.Core.Entities.E_Commerce.ManyToMany;
using Atlet.Core.Entities.Identity;
using Atlet.Core.Entities.Moves.ManyToMany;
using Atlet.DataAccess.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace Atlet.DataAccess.Contexts;

public class AppDbContext:IdentityDbContext<AppUser>
{
	private readonly BaseAuditableInterceptor _interceptor;
	private readonly BasketItemInterceptor _basketItemInterceptor;
	private readonly CommentInterceptor _commentInterceptor;
    public AppDbContext(DbContextOptions<AppDbContext> options, BaseAuditableInterceptor interceptor, BasketItemInterceptor basketItemInterceptor, CommentInterceptor commentInterceptor) : base(options)
    {
        _interceptor = interceptor;
        _basketItemInterceptor = basketItemInterceptor;
        _commentInterceptor = commentInterceptor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
		optionsBuilder.AddInterceptors(_interceptor,_basketItemInterceptor,_commentInterceptor);    
	}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Product>().HasQueryFilter(p => p.IsDeleted == false);
		modelBuilder.Entity<Comment>().HasQueryFilter(p => p.IsDeleted == false);
		modelBuilder.Entity<Blog>().HasQueryFilter(p => p.IsDeleted == false);
		modelBuilder.Entity<Move>().HasQueryFilter(p => p.IsDeleted == false);
		modelBuilder.Entity<Image>().HasQueryFilter(p => p.IsDeleted == false);
    }


    public DbSet<Image> Images { get; set; } = null!;


	public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<BlogCategory> BlogCategories { get; set; } = null!;
	public DbSet<BlogImage> blogImages { get; set; } = null!;


	public DbSet<Product> Products { get; set; } = null!;
	public DbSet<Aroma> Aromas { get; set; } = null!;
	public DbSet<Brand> Brands { get; set; } = null!;
	public DbSet<Comment> Comments { get; set; } = null!;
	public DbSet<ProductCategory> ProductCategories  { get; set; } = null!;
	public DbSet<ProductImage> ProductImages { get; set; } = null!;
	public DbSet<BasketItem> BasketItems { get; set; } = null!;
	public DbSet<Order> Orders { get; set; }=null!;


	public DbSet<Move> Moves { get; set; } = null!;
	public DbSet<Part> Parts { get; set; } = null!;
	public DbSet<MoveImage> MoveImages { get; set; } = null!;


	




}
