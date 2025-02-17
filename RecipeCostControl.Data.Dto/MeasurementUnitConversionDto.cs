namespace RecipeCostControl.Data.Dto
{
    public record struct MeasurementUnitConversionDto(
        string MeasurementUnitFromId,
        decimal Multiplier,
        string MeasurementUnitToId);
}
