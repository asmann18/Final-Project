namespace Atlet.DataAccess.Configurations.E_Commerce;

public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
{
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
        builder.Property(b=>b.IsDeleted).HasDefaultValue(false);
        builder.Property(b=>b.Count).IsRequired();
    }




}




