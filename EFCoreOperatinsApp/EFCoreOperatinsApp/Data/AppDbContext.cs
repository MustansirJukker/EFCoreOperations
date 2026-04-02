using Microsoft.EntityFrameworkCore;

namespace EFCoreOperatinsApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, Title = "INR", Description = "Indian Rupee" },
                new Currency { Id = 2, Title = "USD", Description = "United States Dollar" },
                new Currency { Id = 3, Title = "EUR", Description = "Euro" },
                new Currency { Id = 4, Title = "GBP", Description = "British Pound Sterling" },
                new Currency { Id = 5, Title = "JPY", Description = "Japanese Yen" },
                new Currency { Id = 6, Title = "AUD", Description = "Australian Dollar" },
                new Currency { Id = 7, Title = "CAD", Description = "Canadian Dollar" },
                new Currency { Id = 8, Title = "CNY", Description = "Chinese Yuan" },
                new Currency { Id = 9, Title = "AED", Description = "United Arab Emirates Dirham" },
                new Currency { Id = 10, Title = "SAR", Description = "Saudi Riyal" }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, Title = "Hindi", Description = "Hindi Language" },
                new Language { Id = 2, Title = "English", Description = "English Language" },
                new Language { Id = 3, Title = "French", Description = "French Language" },
                new Language { Id = 4, Title = "Spanish", Description = "Spanish Language" },
                new Language { Id = 5, Title = "German", Description = "German Language" },
                new Language { Id = 6, Title = "Chinese", Description = "Chinese (Mandarin)" },
                new Language { Id = 7, Title = "Arabic", Description = "Arabic Language" },
                new Language { Id = 8, Title = "Portuguese", Description = "Portuguese Language" },
                new Language { Id = 9, Title = "Russian", Description = "Russian Language" },
                new Language { Id = 10, Title = "Japanese", Description = "Japanese Language" }
            );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
