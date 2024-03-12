using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodTotem.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoDadosDoUsuarioNoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserCpf",
                schema: "FastFoodTotem",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "FastFoodTotem",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCpf",
                schema: "FastFoodTotem",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "FastFoodTotem",
                table: "Order");
        }
    }
}
