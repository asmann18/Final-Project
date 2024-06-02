namespace Atlet.DataAccess.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.Property(c => c.Name).IsRequired(true).HasMaxLength(60);
        builder.Property(c => c.Description).IsRequired(true).HasMaxLength(255);
    }
}
