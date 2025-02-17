namespace RecipeCostControl.Data.Dto
{
    public record struct RecipeItemDto(
        int? Id,
        int IngredientId,
        decimal Quantity,
        string MeasurementUnitId);
}