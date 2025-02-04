namespace RecipeCostControl.Data.Dto
{
    public sealed record ProductDto(
        int? Id,
        string Name,
        int RecipeId,
        int? PackagingId,
        string MeasurementUnitId,
        decimal Cost,
        decimal SellingPrice);
}
