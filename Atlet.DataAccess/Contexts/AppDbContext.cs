using Atlet.Core.Entities.Blogs.ManyToMany;
using Atlet.Core.Entities.E_Commerce.ManyToMany;
using Atlet.Core.Entities.Moves.ManyToMany;
using Atlet.DataAccess.Configurations;
using Atlet.DataAccess.Interceptors;
using System.Reflection;

namespace Atlet.DataAccess.Contexts;

public class AppDbContext:DbContext
{
	private readonly BaseAuditableInterceptor _interceptor;
	public AppDbContext(DbContextOptions<AppDbContext> options, BaseAuditableInterceptor interceptor) : base(options)
	{
		_interceptor = interceptor;
	}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
		optionsBuilder.AddInterceptors(_interceptor);    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Product>().HasQueryFilter(p => p.IsDeleted == false);
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



	public DbSet<Move> Moves { get; set; } = null!;
	public DbSet<Part> Parts { get; set; } = null!;
	public DbSet<MoveImage> MoveImages { get; set; } = null!;




}
