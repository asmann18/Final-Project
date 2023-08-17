namespace Atlet.DataAccess.Configurations.E_Commerce;

public class AromaConfiguration : IEntityTypeConfiguration<Aroma>
{
    public void Configure(EntityTypeBuilder<Aroma> builder)
    {
        builder.Property(a => a.Name).IsRequired(true).HasMaxLength(60);
            }
}
