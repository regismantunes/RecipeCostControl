using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Services.Interfaces;

namespace RecipeCostControl.API.Routes
{
    internal static class IdentityEntityMap
    {
        public static void MapEntity<T, TDto>(this IEndpointRouteBuilder builder) where T : class, IIdentityEntity
        {
            builder.MapGet(string.Empty, static async (IService<T> service, IMapper mapper) =>
            {
                var entities = await service.GetAllAsync();
                return Results.Ok(entities.Select(mapper.Map<TDto>));
            });

            builder.MapGet("{id}", static async (IService<T> service, IMapper mapper, int id) =>
            {
                var entity = await service.GetByIdAsync(id);
                if (entity is null)
                    return Results.NotFound();

                return Results.Ok(mapper.Map<TDto>(entity));
            });

            builder.MapPost(string.Empty, static async (IService<T> service, IMapper mapper, [FromBody] TDto value) =>
            {
                var entity = mapper.Map<T>(value);
                entity = await service.InsertAsync(entity);
                return Results.Ok(entity);
            });

            builder.MapPut("{id}", static async (IService<T> service, IMapper mapper, int id, [FromBody] TDto value) =>
            {
                var entity = mapper.Map<T>(value);
                entity.Id = id;
                await service.UpdateAsync(entity);
                return Results.Ok();
            });

            builder.MapDelete("{id}", static async (IService<T> service, int id) =>
            {
                await service.DeleteAsync(id);
                return Results.Ok();
            });
        }
    }
}
