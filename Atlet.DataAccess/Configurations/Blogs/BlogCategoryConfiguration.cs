namespace Atlet.DataAccess.Configurations.Blogs;

public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
{
    public void Configure(EntityTypeBuilder<BlogCategory> builder)
    {
       builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
    }
}
