namespace RecipeCostControl.Data.Dto
{
    public sealed record PackagingDto(
        int? Id,
        string Name,
        string MeasurementUnitId,
        decimal Cost);
}
