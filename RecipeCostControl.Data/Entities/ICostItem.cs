namespace RecipeCostControl.Data.Entities
{
    public interface ICostItem
    {
        string Name { get; }

        string MeasurementUnitId { get; }

        MeasurementUnit MeasurementUnit { get; }

        decimal Cost { get; }
    }
}