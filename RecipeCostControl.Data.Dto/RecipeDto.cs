namespace RecipeCostControl.Data.Dto
{
    public record struct RecipeDto(
        int? Id,
        string Name,
        IEnumerable<RecipeItemDto> Items,
        string MeasurementUnitId,
        decimal YieldQuantity,
        decimal Cost);
}
