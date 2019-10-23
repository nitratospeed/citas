using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class agregado_horarios_colores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
