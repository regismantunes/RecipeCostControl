using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Context.Map.Generic
{
    internal sealed class CostItemMap<T> : IEntityTypeConfiguration<T> where T : class, ICostItem
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasOne(x => x.MeasurementUnit)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.MeasurementUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Cost)
                .IsRequired()
                .HasColumnType(DefaultTypes.Cost);
        }
    }
}
