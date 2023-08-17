namespace Atlet.DataAccess.Configurations.Moves;

public class MoveConfiguration : IEntityTypeConfiguration<Move>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Move> builder)
    {
        builder.Property(m => m.Name).IsRequired(true).HasMaxLength(60);
        builder.Property(m => m.Description).IsRequired(true).HasMaxLength(300);
        builder.Property(p => p.IsDeleted).HasDefaultValue(false);


    }

}
