using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeCostControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementUnits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnitConversions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeasurementUnitFromId = table.Column<string>(type: "TEXT", nullable: false),
                    Multiplier = table.Column<double>(type: "decimal(10,5)", nullable: false),
                    MeasurementUnitToId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnitConversions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasurementUnitConversions_MeasurementUnits_MeasurementUnitFromId",
                        column: x => x.MeasurementUnitFromId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeasurementUnitConversions_MeasurementUnits_MeasurementUnitToId",
                        column: x => x.MeasurementUnitToId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Packaging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MeasurementUnitId = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(8,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packaging", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packaging_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MeasurementUnitId = table.Column<string>(type: "TEXT", nullable: false),
                    YieldQuantity = table.Column<uint>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(8,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MeasurementUnitId = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PackagingId = table.Column<int>(type: "INTEGER", nullable: true),
                    MeasurementUnitId = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Packaging_PackagingId",
                        column: x => x.PackagingId,
                        principalTable: "Packaging",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<uint>(type: "int", nullable: false),
                    MeasurementUnitId = table.Column<string>(type: "TEXT", nullable: false),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeItem_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeItem_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeItem_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MeasurementUnits",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { "gr", "Grama" },
                    { "kg", "Quilo" },
                    { "lt", "Litro" },
                    { "ml", "Mililitro" },
                    { "un", "Unidade" }
                });

            migrationBuilder.InsertData(
                table: "MeasurementUnitConversions",
                columns: new[] { "Id", "MeasurementUnitFromId", "MeasurementUnitToId", "Multiplier" },
                values: new object[,]
                {
                    { 1, "kg", "gr", 0.001 },
                    { 2, "gr", "kg", 1000.0 },
                    { 3, "lt", "ml", 0.001 },
                    { 4, "ml", "lt", 1000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MeasurementUnitId",
                table: "Ingredients",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnitConversions_MeasurementUnitFromId",
                table: "MeasurementUnitConversions",
                column: "MeasurementUnitFromId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnitConversions_MeasurementUnitToId",
                table: "MeasurementUnitConversions",
                column: "MeasurementUnitToId");

            migrationBuilder.CreateIndex(
                name: "IX_Packaging_MeasurementUnitId",
                table: "Packaging",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Packaging_Name",
                table: "Packaging",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MeasurementUnitId",
                table: "Products",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PackagingId",
                table: "Products",
                column: "PackagingId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RecipeId",
                table: "Products",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItem_IngredientId",
                table: "RecipeItem",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItem_MeasurementUnitId",
                table: "RecipeItem",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItem_RecipeId",
                table: "RecipeItem",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MeasurementUnitId",
                table: "Recipes",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Name",
                table: "Recipes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementUnitConversions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RecipeItem");

            migrationBuilder.DropTable(
                name: "Packaging");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "MeasurementUnits");
        }
    }
}
