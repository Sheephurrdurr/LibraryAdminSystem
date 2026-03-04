using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configs
{
    public static class LibraryContextConfig
    {
        public static void ConfigureSqLite(this DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "library.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
