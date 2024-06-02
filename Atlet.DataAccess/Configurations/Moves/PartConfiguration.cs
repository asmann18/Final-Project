
namespace Atlet.DataAccess.Configurations.Moves;

internal class PartConfiguration : IEntityTypeConfiguration<Part>
{
    public void Configure(EntityTypeBuilder<Part> builder)
    {
        builder.Property(p => p.Name).IsRequired(true).HasMaxLength(50);
    }
}
