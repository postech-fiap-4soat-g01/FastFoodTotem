using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodTotem.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class TransformandoGuidsEmInts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FastFoodTotem");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "FastFoodTotem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CategoryId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "FastFoodTotem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CustomerId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "FastFoodTotem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProductId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "FastFoodTotem",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "FastFoodTotem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OrderId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "FastFoodTotem",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderedItem",
                schema: "FastFoodTotem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OrderedItemId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "FastFoodTotem",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "FastFoodTotem",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                schema: "FastFoodTotem",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItem_OrderId",
                schema: "FastFoodTotem",
                table: "OrderedItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItem_ProductId",
                schema: "FastFoodTotem",
                table: "OrderedItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "FastFoodTotem",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedItem",
                schema: "FastFoodTotem");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "FastFoodTotem");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "FastFoodTotem");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "FastFoodTotem");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "FastFoodTotem");
        }
    }
}
