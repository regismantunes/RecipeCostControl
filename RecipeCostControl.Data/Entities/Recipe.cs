namespace RecipeCostControl.Data.Entities
{
    public sealed class Recipe : ICostItem, IIdentityEntity
    {
        public int? Id { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public string Name { get; set; }

        public IEnumerable<RecipeItem> Items { get; set; }

        public string MeasurementUnitId { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public uint YieldQuantity { get; set; }

        public decimal Cost { get; set; }
    }
}
