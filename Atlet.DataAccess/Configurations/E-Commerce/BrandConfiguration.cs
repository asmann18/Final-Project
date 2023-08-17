namespace Atlet.DataAccess.Configurations.E_Commerce
{
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Name).IsRequired(true).HasMaxLength(60);
            builder.Property(b=>b.Description).IsRequired(true).HasMaxLength(300);

        }
    }
}
