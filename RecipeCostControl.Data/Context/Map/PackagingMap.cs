using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCostControl.Data.Context.Map.Generic;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Context.Map
{
    internal sealed class PackagingMap : IEntityTypeConfiguration<Packaging>
    {
        public void Configure(EntityTypeBuilder<Packaging> builder)
        {
            new IdentityEntityMap<Packaging>()
                .Configure(builder);

            new CostItemMap<Packaging>()
                .Configure(builder);
        }
    }
}
