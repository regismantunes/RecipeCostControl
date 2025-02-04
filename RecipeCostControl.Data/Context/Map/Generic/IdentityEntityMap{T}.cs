using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Context.Map.Generic
{
    internal sealed class IdentityEntityMap<T> : IEntityTypeConfiguration<T> where T : class, IIdentityEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
