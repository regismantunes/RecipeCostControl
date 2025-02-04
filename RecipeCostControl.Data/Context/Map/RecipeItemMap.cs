using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCostControl.Data.Context.Map.Generic;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Context.Map
{
    internal sealed class RecipeItemMap : IEntityTypeConfiguration<RecipeItem>
    {
        public void Configure(EntityTypeBuilder<RecipeItem> builder)
        {
            new IdentityEntityMap<RecipeItem>()
                .Configure(builder);

            builder.HasOne(x => x.Ingredient)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnType(DefaultTypes.Quantity);

            builder.HasOne(x => x.MeasurementUnit)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.MeasurementUnitId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
