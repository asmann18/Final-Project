namespace Atlet.DataAccess.Configurations.Blogs;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.Property(b => b.Name).IsRequired(true).HasMaxLength(60);
        builder.Property(b => b.Description).IsRequired(true).HasMaxLength(500);
        builder.Property(p => p.IsDeleted).HasDefaultValue(false);

    }
}
