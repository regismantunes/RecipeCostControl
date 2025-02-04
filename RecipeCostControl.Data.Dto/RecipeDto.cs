namespace RecipeCostControl.Data.Dto
{
    public sealed record RecipeDto(
        int? Id,
        string Name,
        IEnumerable<RecipeItemDto> Items,
        string MeasurementUnitId,
        decimal YieldQuantity,
        decimal Cost);
}
