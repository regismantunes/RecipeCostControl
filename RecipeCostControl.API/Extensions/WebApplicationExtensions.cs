using RecipeCostControl.API.Routes;
using RecipeCostControl.Data.Dto;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.API.Extensions
{
    internal static class WebApplicationExtensions
    {
        public static void AddRoutes(this IEndpointRouteBuilder builder)
        {
            var groupApi = builder.MapGroup("api");

            groupApi.MapGroup("ingredients").MapEntity<Ingredient, IngredientDto>();
            groupApi.MapGroup("packaging").MapEntity<Packaging, PackagingDto>();
            groupApi.MapGroup("products").MapEntity<Product, ProductDto>();
            groupApi.MapGroup("recipes").MapEntity<Recipe, RecipeDto>();
            groupApi.MapGroup("measuremantunit").MapMeasuremantUnit();
        }
    }
}
