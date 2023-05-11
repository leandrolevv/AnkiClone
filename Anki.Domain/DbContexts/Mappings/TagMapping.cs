﻿using Anki.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Anki.Domain.DbContexts.Mappings
{
    public class TagMapping : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Text).HasColumnType("VARCHAR").HasMaxLength(1000).IsRequired();
            builder
                .HasIndex(x => x.Text, "IX_Tag_Text")
                .IsUnique();
        }
    }
    
}
