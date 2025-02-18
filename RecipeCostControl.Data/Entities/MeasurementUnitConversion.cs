namespace RecipeCostControl.Data.Entities
{
    public sealed class MeasurementUnitConversion : IIdentityEntity
    {
        public int? Id { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public string MeasurementUnitFromId { get; set; }

        public MeasurementUnit MeasurementUnitFrom { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public double Multiplier { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public string MeasurementUnitToId { get; set; }

        public MeasurementUnit MeasurementUnitTo { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    }
}
