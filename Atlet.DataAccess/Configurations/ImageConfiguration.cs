using Atlet.Core.Entities;

namespace Atlet.DataAccess.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.Property(i => i.Path).IsRequired(true).HasMaxLength(500);
        builder.Property(i => i.Alt).HasDefaultValue("img").HasMaxLength(30);
    }
}
