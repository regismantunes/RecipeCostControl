using Microsoft.EntityFrameworkCore;

namespace RecipeCostControl.Data.Extensions
{
    public static class DbContextOptionsBuilderExtensions
    {
        private const string DefaultConnectionString = "Data Source=recipecostcontrol.db";

        public static DbContextOptionsBuilder Configure(this DbContextOptionsBuilder optionsBuilder, string? connectionString = null)
        {
            return optionsBuilder.UseSqlite(connectionString ?? DefaultConnectionString);
        }

        public static DbContextOptionsBuilder<T> Configure<T>(this DbContextOptionsBuilder<T> optionsBuilder, string? connectionString = null) where T : DbContext
        {
            return optionsBuilder.UseSqlite(connectionString ?? DefaultConnectionString);
        }
    }
}
