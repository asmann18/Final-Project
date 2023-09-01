namespace Atlet.DataAccess.Configurations.E_Commerce;


public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(b => b.IsDeleted).HasDefaultValue(false);
        builder.Property(b => b.Count).IsRequired();
        builder.Property(b => b.staticPrice).IsRequired().HasColumnType("decimal(18,2)");
    }




}
