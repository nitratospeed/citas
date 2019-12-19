using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class fixed_model_hc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreCliente",
                table: "Citas",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Movil",
                table: "Citas",
                newName: "Correo");

            migrationBuilder.RenameColumn(
                name: "CorreoCliente",
                table: "Citas",
                newName: "Celular");

            migrationBuilder.CreateTable(
                name: "HistoriaClinicas",
                columns: table => new
                {
                    IdHistoriaClinica = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DNI = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaClinicas", x => x.IdHistoriaClinica);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoriaClinicas");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Citas",
                newName: "NombreCliente");

            migrationBuilder.RenameColumn(
                name: "Correo",
                table: "Citas",
                newName: "Movil");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "Citas",
                newName: "CorreoCliente");
        }
    }
}
