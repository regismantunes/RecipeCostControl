namespace RecipeCostControl.Data.Dto
{
    public sealed record MeasurementUnitConversionDto(
        string MeasurementUnitFromId,
        decimal Multiplier,
        string MeasurementUnitToId);
}
