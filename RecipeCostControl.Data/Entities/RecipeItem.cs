namespace RecipeCostControl.Data.Entities
{
    public sealed class RecipeItem : IIdentityEntity
    {
        public int? Id { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

        public uint Quantity { get; set; }

        public string MeasurementUnitId { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}