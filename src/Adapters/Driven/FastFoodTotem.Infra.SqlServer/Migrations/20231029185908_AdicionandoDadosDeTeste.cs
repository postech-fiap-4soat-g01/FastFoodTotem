using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastFoodTotem.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoDadosDeTeste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "FastFoodTotem",
                table: "Customer",
                columns: new[] { "Id", "Email", "Identification", "Name" },
                values: new object[,]
                {
                    { 1, "joao_joao@joao.com", "86617589041", "João José" },
                    { 2, "maria_maria@maria.com", "56419341000", "Maria José" }
                });

            migrationBuilder.InsertData(
                schema: "FastFoodTotem",
                table: "Product",
                columns: new[] { "Id", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Hamburguer", 13m, 1 },
                    { 2, "X-Burguer", 20m, 1 },
                    { 3, "X-Bacon", 25m, 1 },
                    { 4, "X-Frango", 25m, 1 },
                    { 5, "X-Salada", 15m, 1 },
                    { 6, "Batata Pequena", 5m, 2 },
                    { 7, "Batata Média", 7m, 2 },
                    { 8, "Batata Grande", 9m, 2 },
                    { 9, "Onion Ring Pequeno", 5m, 2 },
                    { 10, "Onion Ring Médio", 7m, 2 },
                    { 11, "Onion Ring Grande", 9m, 2 },
                    { 12, "Coca Cola Lata", 6m, 3 },
                    { 13, "Fanta Laranja Lata", 6m, 3 },
                    { 14, "Fanta Guaraná Lata", 6m, 3 },
                    { 15, "Sprite Lata", 6m, 3 },
                    { 16, "Fanta Uva Lata", 6m, 3 },
                    { 17, "Picolé Chocolate", 6m, 4 },
                    { 18, "Sorvete Casquinha", 3m, 4 },
                    { 19, "Pudim", 7m, 4 },
                    { 20, "Mousse de Maracujá", 10.5m, 4 },
                    { 21, "Torta de Morango", 13m, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "FastFoodTotem",
                table: "Product",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
