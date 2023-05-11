using Anki.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anki.Domain.DbContexts.Mappings
{
    public class DeckMapping : IEntityTypeConfiguration<Deck>
    {
        public void Configure(EntityTypeBuilder<Deck> builder)
        {
            builder.ToTable("Deck");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired().HasColumnType("VARCHAR");
            builder.HasIndex(x => x.Title, "IDX_Title_Deck").IsUnique();
            builder.HasMany(x => x.Cards).WithOne().IsRequired().HasConstraintName("FK_Deck_Card").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
