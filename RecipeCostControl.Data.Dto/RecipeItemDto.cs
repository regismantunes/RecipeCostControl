namespace RecipeCostControl.Data.Dto
{
    public sealed record RecipeItemDto(
        int? Id,
        int IngredientId,
        decimal Quantity,
        string MeasurementUnitId);
}