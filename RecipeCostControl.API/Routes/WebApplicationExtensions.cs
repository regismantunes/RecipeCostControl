using RecipeCostControl.Data.Dto;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.API.Routes
{
    internal static class WebApplicationExtensions
    {
        public static void AddRoutes(this IEndpointRouteBuilder builder)
        {
            var groupApi = builder.MapGroup("api");

            groupApi.MapGroup("ingredients").AddMinimalApi<Ingredient, IngredientDto>();
            groupApi.MapGroup("packaging").AddMinimalApi<Packaging, PackagingDto>();
            groupApi.MapGroup("products").AddMinimalApi<Product, ProductDto>();
            groupApi.MapGroup("recipes").AddMinimalApi<Recipe, RecipeDto>();
            groupApi.MapGroup("measuremantunit").AddMeasuremantUnitMinimalApi();
        }
    }
}
