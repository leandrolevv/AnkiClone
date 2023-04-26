using Anki.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anki.Domain.DbContexts.Mappings
{
    public class CardMapping : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Card");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Front).HasColumnType("VARCHAR").HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Back).HasColumnType("VARCHAR").HasMaxLength(1000).IsRequired();
            //builder.HasMany(x => x.Tags).WithOne().HasConstraintName("FK_CARD_TAGID").HasConstraintName("TAG_ID");
            builder
                .HasMany(x => x.Tags)
                .WithMany(x => x.Cards)
                .UsingEntity<Dictionary<string, object>>(
                    "CardTag",
                    card =>
                        card
                            .HasOne<Tag>()
                            .WithMany()
                            .HasForeignKey("Card_Id")
                            .HasConstraintName("FK_CARDTAG_CARDID"),
                    tag =>
                        tag
                            .HasOne<Card>()
                            .WithMany()
                            .HasForeignKey("Tag_Id")
                            .HasConstraintName("FK_CARDTAG_TAGID")
                );
        }
    }
}
