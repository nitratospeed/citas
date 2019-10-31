using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class fix_models6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "HorarioFin",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "HorarioInicio",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "FechaCita",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Citas");

            migrationBuilder.RenameColumn(
                name: "Duracion",
                table: "Citas",
                newName: "IdTipo");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFinCita",
                table: "Citas",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicioCita",
                table: "Citas",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFinCita",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "FechaInicioCita",
                table: "Citas");

            migrationBuilder.RenameColumn(
                name: "IdTipo",
                table: "Citas",
                newName: "Duracion");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Medicos",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioFin",
                table: "Medicos",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioInicio",
                table: "Medicos",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCita",
                table: "Citas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Citas",
                nullable: true);
        }
    }
}
