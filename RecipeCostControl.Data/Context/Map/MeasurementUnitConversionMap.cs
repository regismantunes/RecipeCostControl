using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCostControl.Data.Context.Map.Generic;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Context.Map
{
    internal sealed class MeasurementUnitConversionMap : IEntityTypeConfiguration<MeasurementUnitConversion>
    {
        public void Configure(EntityTypeBuilder<MeasurementUnitConversion> builder)
        {
            new IdentityEntityMap<MeasurementUnitConversion>()
                .Configure(builder);

            builder.HasOne(x => x.MeasurementUnitTo)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.MeasurementUnitToId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.MeasurementUnitFrom)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.MeasurementUnitFromId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Multiplier)
                .IsRequired()
                .HasColumnType(DefaultTypes.ConversionMultiplier);

            builder.HasData(
                new MeasurementUnitConversion() { Id = 1, MeasurementUnitFromId = "kg", MeasurementUnitToId = "gr", Multiplier = 0.001 },
                new MeasurementUnitConversion() { Id = 2, MeasurementUnitFromId = "gr", MeasurementUnitToId = "kg", Multiplier = 1000 },
                new MeasurementUnitConversion() { Id = 3, MeasurementUnitFromId = "lt", MeasurementUnitToId = "ml", Multiplier = 0.001 },
                new MeasurementUnitConversion() { Id = 4, MeasurementUnitFromId = "ml", MeasurementUnitToId = "lt", Multiplier = 1000 }
                );
        }
    }
}
