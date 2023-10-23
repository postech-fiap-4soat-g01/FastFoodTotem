using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodTotem.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class MudandoPropriedades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "FastFoodTotem",
                table: "Product",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 255);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Name",
                schema: "FastFoodTotem",
                table: "Product",
                type: "uniqueidentifier",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
