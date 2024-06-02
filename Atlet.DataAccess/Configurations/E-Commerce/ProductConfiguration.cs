namespace Atlet.DataAccess.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(255);
            builder.Property(p => p.Description).IsRequired(true).HasMaxLength(255);
            builder.Property(p => p.Price).IsRequired(true).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Count).IsRequired(true);
            builder.Property(p => p.SalesCount).HasDefaultValue(0);
            builder.Property(p => p.Rating).HasDefaultValue(0);
            builder.Property(p => p.Discount).HasDefaultValue(0);
            builder.Property(p => p.BrandId).IsRequired(true);
            builder.Property(p => p.AromaId).IsRequired(true);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);


            builder.HasCheckConstraint("CK_Product_Price", "Price >= 0");
            builder.HasCheckConstraint("CK_Product_Count", "Count >= 0");
            builder.HasCheckConstraint("CK_Product_SalesCount", "SalesCount >= 0");
            builder.HasCheckConstraint("CK_Product_SalesCount", "Rating >= 0 AND Rating <=5");
            builder.HasCheckConstraint("CK_Product_Discount", "Discount >= 0 AND Discount <=100");


        }
    }
}
