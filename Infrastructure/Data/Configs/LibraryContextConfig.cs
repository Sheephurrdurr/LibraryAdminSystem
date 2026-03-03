using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configs
{
    public static class LibraryContextConfig
    {
        public static void ConfigureSqLite(this DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=library.db");
        }
    }
}
