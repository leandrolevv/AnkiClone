using Anki.Domain.DbContexts.Mappings;
using Anki.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anki.Domain.DbContexts
{
    public class AnkiDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=anki;User Id=sa;Password=leandro12345;encrypt=true;trustservercertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TagMapping());
            modelBuilder.ApplyConfiguration(new CardMapping());
            modelBuilder.ApplyConfiguration(new DeckMapping());
        }
    }
}
