namespace RecipeCostControl.Data.Entities
{
    public sealed class Recipe : ICostItem, IIdentityEntity
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<RecipeItem> Items { get; set; }

        public string MeasurementUnitId { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }

        public uint YieldQuantity { get; set; }

        public decimal Cost { get; set; }
    }
}
