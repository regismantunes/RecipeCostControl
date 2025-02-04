namespace RecipeCostControl.Data.Entities
{
    public sealed class Product : ICostItem, IIdentityEntity
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int? PackagingId { get; set; }

        public Packaging? Packaging { get; set; }

        public string MeasurementUnitId { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }

        public decimal Cost { get; set; }

        public decimal SellingPrice { get; set; }
    }
}
