using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCDI.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCategoriaInsumo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertaEstoqueBaixo",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "EstoqueAtual",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "EstoqueMinimo",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "UnidadeMedida",
                table: "Insumos");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Insumos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitario",
                table: "Insumos",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "PrecoUnitario",
                table: "Insumos");

            migrationBuilder.AddColumn<bool>(
                name: "AlertaEstoqueBaixo",
                table: "Insumos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "EstoqueAtual",
                table: "Insumos",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EstoqueMinimo",
                table: "Insumos",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UnidadeMedida",
                table: "Insumos",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
