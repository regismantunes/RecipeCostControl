namespace RecipeCostControl.Data.Dto
{
    public record struct IngredientDto(
        int? Id,
        string Name,
        string MeasurementUnitId,
        decimal Cost,
        int? RecipeId
        );
}
