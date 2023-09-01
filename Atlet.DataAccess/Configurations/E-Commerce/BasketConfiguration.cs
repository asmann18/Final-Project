namespace Atlet.DataAccess.Configurations.E_Commerce;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.Property(b => b.IsSold).HasDefaultValue(false);
        builder.Property(b => b.IsDeleted).HasDefaultValue(false);
        builder.Property(b => b.TotalCount).HasColumnType("decimal(18,2)");

    }
}
