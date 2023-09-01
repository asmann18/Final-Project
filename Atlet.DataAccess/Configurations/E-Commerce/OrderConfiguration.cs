namespace Atlet.DataAccess.Configurations.E_Commerce;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(b => b.IsDeleted).HasDefaultValue(false);
        builder.Property(b => b.TotalCount).HasColumnType("decimal(18,2)");
    }
}
