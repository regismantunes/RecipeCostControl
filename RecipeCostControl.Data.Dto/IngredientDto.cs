namespace RecipeCostControl.Data.Dto
{
    public sealed record IngredientDto(
        int? Id,
        string Name,
        string MeasurementUnitId,
        decimal Cost,
        int? RecipeId
        );
}
