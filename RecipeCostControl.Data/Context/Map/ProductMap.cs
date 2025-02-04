using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCostControl.Data.Context.Map.Generic;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Context.Map
{
    internal sealed class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            new IdentityEntityMap<Product>()
                .Configure(builder);

            new CostItemMap<Product>()
                .Configure(builder);

            builder.HasOne(x => x.Recipe)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.RecipeId);

            builder.HasOne(x => x.Packaging)
                .WithMany()
                .HasForeignKey(x => x.PackagingId);

            builder.Property(x => x.SellingPrice)
                .IsRequired()
                .HasColumnType(DefaultTypes.Price);
        }
    }
}
