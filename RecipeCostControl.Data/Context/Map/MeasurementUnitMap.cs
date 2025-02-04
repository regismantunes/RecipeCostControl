using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Context.Map
{
    internal sealed class MeasurementUnitMap : IEntityTypeConfiguration<MeasurementUnit>
    {
        public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new MeasurementUnit { Id = "kg", Description = "Quilo" },
                new MeasurementUnit { Id = "gr", Description = "Grama" },
                new MeasurementUnit { Id = "lt", Description = "Litro" },
                new MeasurementUnit { Id = "ml", Description = "Mililitro" },
                new MeasurementUnit { Id = "un", Description = "Unidade" }
                );
        }
    }
}
