using Atlet.Core.Entities.E_Commerce.ManyToMany;

namespace Atlet.DataAccess.Configurations.E_Commerce;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.isDelivery).HasDefaultValue(false);
        builder.Property(o => o.Location).HasMaxLength(50);
    }
}
