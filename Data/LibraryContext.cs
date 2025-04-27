using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data
{
    public class LibraryContext : DbContext
    {
        // 1) Parameterless ctor ekliyoruz:
        public LibraryContext() { }

        // 2) Varsayılan ctor
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Book>   Books   { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Eğer DI ile konfigürasyon gelmemişse, buradan fallback bağlantıyı sağlayalım:
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                  "Server=(localdb)\\mssqllocaldb;Database=LibraryDB;Trusted_Connection=True;"
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author!)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
