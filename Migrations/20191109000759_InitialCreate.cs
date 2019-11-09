using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    IdMedico = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Nombres = table.Column<string>(nullable: true),
                    Especialidad = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    FechaNac = table.Column<DateTime>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.IdMedico);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    IdTipo = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Descripcion = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.IdTipo);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Nombres = table.Column<string>(nullable: true),
                    Dni = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    IdHorario = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    IdMedico = table.Column<int>(nullable: false),
                    Sede = table.Column<int>(nullable: false),
                    Dia = table.Column<string>(nullable: true),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    HoraFin = table.Column<TimeSpan>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.IdHorario);
                    table.ForeignKey(
                        name: "FK_Horarios_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    IdCita = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    IdMedico = table.Column<int>(nullable: false),
                    NombreCliente = table.Column<string>(nullable: true),
                    Movil = table.Column<string>(nullable: true),
                    CorreoCliente = table.Column<string>(nullable: true),
                    FechaInicioCita = table.Column<DateTime>(nullable: false),
                    FechaFinCita = table.Column<DateTime>(nullable: false),
                    IdTipo = table.Column<int>(nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.IdCita);
                    table.ForeignKey(
                        name: "FK_Citas_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Tipos_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "Tipos",
                        principalColumn: "IdTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdMedico",
                table: "Citas",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdTipo",
                table: "Citas",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_IdMedico",
                table: "Horarios",
                column: "IdMedico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
