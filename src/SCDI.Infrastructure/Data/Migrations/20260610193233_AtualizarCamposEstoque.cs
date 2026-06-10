using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCDI.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarCamposEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Insumos");

            migrationBuilder.AddColumn<int>(
                name: "LimiteMinimoAlerta",
                table: "Insumos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Insumos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimiteMinimoAlerta",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Insumos");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Insumos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
