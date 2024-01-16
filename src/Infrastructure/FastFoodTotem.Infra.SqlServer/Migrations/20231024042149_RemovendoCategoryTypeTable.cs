using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodTotem.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoCategoryTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                schema: "FastFoodTotem",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "FastFoodTotem");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                schema: "FastFoodTotem",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "FastFoodTotem",
                table: "Product",
                newName: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "FastFoodTotem",
                table: "Product",
                newName: "CategoryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "FastFoodTotem",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                schema: "FastFoodTotem",
                table: "Product",
                column: "CategoryId",
                principalSchema: "FastFoodTotem",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
