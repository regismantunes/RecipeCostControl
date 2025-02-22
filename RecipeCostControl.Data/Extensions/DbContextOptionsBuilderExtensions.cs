using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RecipeCostControl.Data.Extensions
{
    public static class DbContextOptionsBuilderExtensions
    {
        private const string ConnectionStringName = "Default";

        public static T UseConfiguration<T>(this T optionsBuilder, IConfiguration configuration) where T : DbContextOptionsBuilder
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringName);
            return (T)optionsBuilder.UseSqlite(connectionString);
        }
    }
}
