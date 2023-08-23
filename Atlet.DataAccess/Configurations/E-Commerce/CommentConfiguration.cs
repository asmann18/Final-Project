namespace Atlet.DataAccess.Configurations.E_Commerce;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(c=>c.Text).IsRequired(true).HasMaxLength(128);
        builder.Property(c => c.Rating).IsRequired(true);
        builder.HasCheckConstraint("Rating", "Rating BETWEEN 0 AND 5");
        builder.Property(p => p.IsDeleted).HasDefaultValue(false);

    }
}
