using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCostControl.Data.Context.Map.Generic;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Context.Map
{
    internal sealed class IngredientMap : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            new IdentityEntityMap<Ingredient>()
                .Configure(builder);

            new CostItemMap<Ingredient>()
                .Configure(builder);

            builder.HasOne(x => x.Recipe)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.RecipeId);
        }
    }
}
