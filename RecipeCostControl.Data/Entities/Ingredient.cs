namespace RecipeCostControl.Data.Entities
{
    public sealed class Ingredient : ICostItem, IIdentityEntity
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string MeasurementUnitId { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }

        public decimal Cost { get; set; }

        public int? RecipeId { get; set; }

        public Recipe? Recipe { get; set; }
    }
}
