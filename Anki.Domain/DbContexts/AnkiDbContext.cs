using Anki.Domain.DbContexts.Mappings;
using Anki.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anki.Domain.DbContexts
{
    public class AnkiDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=anki;User Id=sa;Password=leandro12345;encrypt=true;trustservercertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardMapping());
        }
    }
}
