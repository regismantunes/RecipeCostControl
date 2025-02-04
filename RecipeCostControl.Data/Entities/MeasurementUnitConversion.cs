namespace RecipeCostControl.Data.Entities
{
    public sealed class MeasurementUnitConversion : IIdentityEntity
    {
        public int? Id { get; set; }

        public string MeasurementUnitFromId { get; set; }

        public MeasurementUnit MeasurementUnitFrom { get; set; }

        public double Multiplier { get; set; }

        public string MeasurementUnitToId { get; set; }

        public MeasurementUnit MeasurementUnitTo { get; set; }
    }
}
