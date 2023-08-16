using Atlet.Core.Entities;
using Atlet.Core.Entities.Blog;
using Atlet.Core.Entities.Blog.ManyToMany;
using Atlet.Core.Entities.E_Commerce;
using Atlet.Core.Entities.E_Commerce.ManyToMany;
using Atlet.Core.Entities.Move;
using Atlet.Core.Entities.Move.ManyToMany;
using Atlet.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Atlet.DataAccess.Contexts;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
	{}


	public DbSet<Image> Images { get; set; } = null!;


	public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<BlogCategory> BlogCategories { get; set; } = null!;
    public DbSet<BlogImage> blogImages { get; set; } = null!;


    public DbSet<Product> Products { get; set; } = null!;
	public DbSet<Aroma> Aromas { get; set; } = null!;
	public DbSet<Brand> Brands { get; set; } = null!;
	public DbSet<Comment> Comments { get; set; } = null!;
	public DbSet<ProductCategory> ProductCategories  { get; set; } = null!;
    public DbSet<ProductImage> ProductImages  { get; set; } = null!;



    public DbSet<Move> Moves { get; set; } = null!;
	public DbSet<Part> Parts { get; set; } = null!;
	public DbSet<MoveImage> MoveImages { get; set; } = null!;



	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
		base.OnModelCreating(modelBuilder);
	}


}
