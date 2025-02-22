namespace RecipeCostControl.Data.Entities
{
    public sealed class RecipeItem : IIdentityEntity
    {
        public int? Id { get; set; }

        public int IngredientId { get; set; }

        public required Ingredient Ingredient { get; set; }

        public uint Quantity { get; set; }

        public required string MeasurementUnitId { get; set; }

        public required MeasurementUnit MeasurementUnit { get; set; }

        public int RecipeId { get; set; }

        public required Recipe Recipe { get; set; }
    }
}