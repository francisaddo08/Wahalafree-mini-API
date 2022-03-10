using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WahalafreeAPI.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "occasions",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    promoted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_occasions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    stockLevel = table.Column<int>(type: "int", nullable: false),
                    justLanded = table.Column<bool>(type: "bit", nullable: false),
                    pdesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subregion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ingredientcount = table.Column<int>(type: "int", nullable: false),
                    promoted = table.Column<bool>(type: "bit", nullable: false),
                    recipeDes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    desDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productCategories",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCategories", x => new { x.ProductID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_productCategories_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productCategories_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productOccasions",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccasionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productOccasions", x => new { x.ProductID, x.OccasionID });
                    table.ForeignKey(
                        name: "FK_productOccasions_occasions_OccasionID",
                        column: x => x.OccasionID,
                        principalTable: "occasions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productOccasions_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productRecicpes",
                columns: table => new
                {
                    RecipeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productRecicpes", x => new { x.ProductID, x.RecipeID });
                    table.ForeignKey(
                        name: "FK_productRecicpes_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productRecicpes_recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipeDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    recipeid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    line4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    line5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    line6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    line7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    line8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    line9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    line10 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipeDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_recipeDetails_recipes_recipeid",
                        column: x => x.recipeid,
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recipeOccasions",
                columns: table => new
                {
                    OccasionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecipeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipeOccasions", x => new { x.RecipeID, x.OccasionID });
                    table.ForeignKey(
                        name: "FK_recipeOccasions_occasions_OccasionID",
                        column: x => x.OccasionID,
                        principalTable: "occasions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipeOccasions_recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productCategories_CategoryID",
                table: "productCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_productOccasions_OccasionID",
                table: "productOccasions",
                column: "OccasionID");

            migrationBuilder.CreateIndex(
                name: "IX_productRecicpes_RecipeID",
                table: "productRecicpes",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_recipeDetails_recipeid",
                table: "recipeDetails",
                column: "recipeid");

            migrationBuilder.CreateIndex(
                name: "IX_recipeOccasions_OccasionID",
                table: "recipeOccasions",
                column: "OccasionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productCategories");

            migrationBuilder.DropTable(
                name: "productOccasions");

            migrationBuilder.DropTable(
                name: "productRecicpes");

            migrationBuilder.DropTable(
                name: "recipeDetails");

            migrationBuilder.DropTable(
                name: "recipeOccasions");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "occasions");

            migrationBuilder.DropTable(
                name: "recipes");
        }
    }
}
