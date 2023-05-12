using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class StanzeContext : DbContext
    {
        public DbSet<Stanza> Stanze { get; set; }


        public StanzeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stanza>().HasKey(x => x.Id);
            modelBuilder.Entity<Stanza>().Property(x => x.Nome).IsRequired().HasMaxLength(50);
        }
    }
}
