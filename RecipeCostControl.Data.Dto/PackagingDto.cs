namespace RecipeCostControl.Data.Dto
{
    public record struct PackagingDto(
        int? Id,
        string Name,
        string MeasurementUnitId,
        decimal Cost);
}
