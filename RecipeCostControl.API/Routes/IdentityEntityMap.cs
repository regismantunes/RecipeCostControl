using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Services.Interfaces;

namespace RecipeCostControl.API.Routes
{
    internal static class IdentityEntityMap
    {
        public static void AddMinimalApi<T, TDto>(this IEndpointRouteBuilder builder) where T : class, IIdentityEntity
        {
            builder.MapGet("", async (IService<T> service, IMapper mapper) =>
            {
                var entities = await service.GetAllAsync();
                return Results.Ok(entities.Select(mapper.Map<TDto>));
            });

            builder.MapGet("{id}", async (IService<T> service, IMapper mapper, int id) =>
            {
                var entity = await service.GetByIdAsync(id);
                if (entity is null)
                    return Results.NotFound();

                return Results.Ok(mapper.Map<TDto>(entity));
            });

            builder.MapPost("", async (IService<T> service, IMapper mapper, [FromBody] TDto value) =>
            {
                var entity = mapper.Map<T>(value);
                entity = await service.InsertAsync(entity);
                return Results.Ok(entity);
            });

            builder.MapPut("{id}", async (IService<T> service, IMapper mapper, int id, [FromBody] TDto value) =>
            {
                var entity = mapper.Map<T>(value);
                entity.Id = id;
                await service.UpdateAsync(entity);
                return Results.Ok();
            });

            builder.MapDelete("{id}", async (IService<T> service, int id) =>
            {
                await service.DeleteAsync(id);
                return Results.Ok();
            });
        }
    }
}
