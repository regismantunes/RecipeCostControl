using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCostControl.Data.Context.Map.Generic;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Context.Map
{
    internal sealed class RecipeMap : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            new IdentityEntityMap<Recipe>()
                .Configure(builder);

            new CostItemMap<Recipe>()
                .Configure(builder);

            builder.HasMany(x => x.Items)
                .WithOne(i => i.Recipe)
                .HasForeignKey(i => i.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.YieldQuantity)
                .IsRequired()
                .HasColumnType(DefaultTypes.Quantity);
        }
    }
}
