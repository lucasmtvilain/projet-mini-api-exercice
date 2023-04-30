using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_mini_api.Migrations
{
    /// <inheritdoc />
    public partial class createDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMealAPI = table.Column<int>(type: "int", nullable: false),
                    StrImageSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrDrinkAlternate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMealThumb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrTags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrYoutube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeasure20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrCreativeCommonsConfirmed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealRestaurant",
                columns: table => new
                {
                    MealsId = table.Column<int>(type: "int", nullable: false),
                    RestaurantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealRestaurant", x => new { x.MealsId, x.RestaurantsId });
                    table.ForeignKey(
                        name: "FK_MealRestaurant_Meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealRestaurant_Restaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealRestaurant_RestaurantsId",
                table: "MealRestaurant",
                column: "RestaurantsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealRestaurant");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
