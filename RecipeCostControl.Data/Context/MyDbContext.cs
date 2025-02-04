using Microsoft.EntityFrameworkCore;
using RecipeCostControl.Data.Context.Map;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Context
{
    public sealed class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
    {
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public DbSet<MeasurementUnitConversion> MeasurementUnitConversions { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Packaging> Packaging { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MeasurementUnitMap())
						.ApplyConfiguration(new MeasurementUnitConversionMap())
                        .ApplyConfiguration(new IngredientMap())
						.ApplyConfiguration(new PackagingMap())
						.ApplyConfiguration(new ProductMap())
						.ApplyConfiguration(new RecipeItemMap())
						.ApplyConfiguration(new RecipeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
