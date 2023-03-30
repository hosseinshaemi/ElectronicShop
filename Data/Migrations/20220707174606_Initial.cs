using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEshop.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    QuantityInStock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryToProducts",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryToProducts", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryToProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryToProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "This is first course", "Asp.Net Core" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "This is second course", "React js" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "This is third course", "Vue js" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 4, "This is fourth course", "Express js" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "QuantityInStock" },
                values: new object[] { 1, 854.0m, 5 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "QuantityInStock" },
                values: new object[] { 2, 3302.0m, 8 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "QuantityInStock" },
                values: new object[] { 3, 2580.0m, 3 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 1, "This is product 1 and is very good", 1, "Product 1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 2, "This is product 2 and is very good", 2, "Product 2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 3, "This is product 3 and is very good", 3, "Product 3" });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryToProducts_CategoryId",
                table: "CategoryToProducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemId",
                table: "Products",
                column: "ItemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryToProducts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
