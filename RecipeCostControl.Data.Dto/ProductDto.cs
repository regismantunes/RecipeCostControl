namespace RecipeCostControl.Data.Dto
{
    public record struct ProductDto(
        int? Id,
        string Name,
        int RecipeId,
        int? PackagingId,
        string MeasurementUnitId,
        decimal Cost,
        decimal SellingPrice);
}
