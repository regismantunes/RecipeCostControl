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

            builder.MapPost(string.Empty, static async (IService<T> service, IMapper mapper, LinkGenerator linkGenerator, HttpContext context, [FromBody] TDto value) =>
            {
                var entity = mapper.Map<T>(value);
                entity = await service.InsertAsync(entity);

                var uri = linkGenerator.GetPathByAction(context, $"Get{typeof(T).Name}ById", null, new { id = entity.Id });
                return Results.Created(uri, entity);
            });

            builder.MapPut("{id}", static async (IService<T> service, IMapper mapper, int id, [FromBody] TDto value) =>
            {
                var entity = mapper.Map<T>(value);
                entity.Id = id;

                return await service.UpdateAsync(entity) ?
                    Results.NoContent() :
                    Results.NotFound();
            });

            builder.MapDelete("{id}", static async (IService<T> service, int id) =>
            {
                return await service.DeleteAsync(id) ?
                    Results.NoContent() :
                    Results.NotFound();
            });
        }
    }
}
