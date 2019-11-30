using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class remove_unused : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Especialidad",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "FechaNac",
                table: "Medicos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Especialidad",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNac",
                table: "Medicos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
