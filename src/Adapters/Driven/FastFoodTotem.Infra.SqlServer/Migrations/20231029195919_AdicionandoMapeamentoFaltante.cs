using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodTotem.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoMapeamentoFaltante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "FastFoodTotem",
                table: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "FastFoodTotem",
                table: "Order",
                column: "CustomerId",
                principalSchema: "FastFoodTotem",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "FastFoodTotem",
                table: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "FastFoodTotem",
                table: "Order",
                column: "CustomerId",
                principalSchema: "FastFoodTotem",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
