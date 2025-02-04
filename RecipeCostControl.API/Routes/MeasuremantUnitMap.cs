using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeCostControl.Data.Dto;
using RecipeCostControl.Services.Interfaces;

namespace RecipeCostControl.API.Routes
{
    internal static class MeasuremantUnitMap
    {
        public static void AddMeasuremantUnitMinimalApi(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("", async (IMeasuremantUnitService service, IMapper mapper) =>
            {
                var entities = await service.GetAllAsync();
                return Results.Ok(entities.Select(mapper.Map<MeasurementUnitDto>));
            });

            builder.MapGet("conversion/{idFrom}/{idTo}", async (IMeasuremantUnitService service, IMapper mapper, string idFrom, string idTo) =>
            {
                var entity = await service.GetConversionAsync(idFrom, idTo);
                if (entity is null)
                    return Results.NotFound();

                return Results.Ok(mapper.Map<MeasurementUnitConversionDto>(entity));
            });

            builder.MapGet("conversion/from/{id}", async (IMeasuremantUnitService service, IMapper mapper, string id) =>
            {
                var entities = await service.GetAllConversionsFrom(id)
                    .ToArrayAsync();

                return Results.Ok(entities.Select(mapper.Map<MeasurementUnitConversionDto>));
            });

            builder.MapGet("conversion/to/{id}", async (IMeasuremantUnitService service, IMapper mapper, string id) =>
            {
                var entities = await service.GetAllConversionsTo(id)
                    .ToArrayAsync();

                return Results.Ok(entities.Select(mapper.Map<MeasurementUnitConversionDto>));
            });

            builder.MapGet("conversion", async (IMeasuremantUnitService service, IMapper mapper) =>
            {
                var entities = await service.GetAllConversions()
                    .ToArrayAsync();

                return Results.Ok(entities.Select(mapper.Map<MeasurementUnitConversionDto>));
            });
        }
    }
}
