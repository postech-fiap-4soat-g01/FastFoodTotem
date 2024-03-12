using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastFoodTotem.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoFuncionalidadeDeUsuariosDoMonolito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "FastFoodTotem",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "FastFoodTotem");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                schema: "FastFoodTotem",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "FastFoodTotem",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "FastFoodTotem",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "FastFoodTotem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CustomerId", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "FastFoodTotem",
                table: "Customer",
                columns: new[] { "Id", "Email", "Identification", "Name" },
                values: new object[,]
                {
                    { 1, "joao_joao@joao.com", "86617589041", "João José" },
                    { 2, "maria_maria@maria.com", "56419341000", "Maria José" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                schema: "FastFoodTotem",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                schema: "FastFoodTotem",
                table: "Order",
                column: "CustomerId",
                principalSchema: "FastFoodTotem",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
