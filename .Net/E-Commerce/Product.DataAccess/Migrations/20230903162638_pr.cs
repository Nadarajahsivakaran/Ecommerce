using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class pr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsDelete = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CreatedAt", "IsDelete", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Electronics", new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(8973), 0, new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(8990) },
                    { 2, "Furniture", new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(8992), 0, new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(8993) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsDelete", "Price", "ProductName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(9140), null, null, 0, 55250m, "Phones", new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(9141) },
                    { 2, 2, new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(9145), null, null, 0, 95000m, "Sofa", new DateTime(2023, 9, 3, 21, 56, 38, 653, DateTimeKind.Local).AddTicks(9145) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
