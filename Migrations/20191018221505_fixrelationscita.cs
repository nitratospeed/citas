using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class fixrelationscita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Medicos_IdMedico",
                table: "Citas");

            migrationBuilder.AlterColumn<int>(
                name: "IdMedico",
                table: "Citas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Medicos_IdMedico",
                table: "Citas",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Medicos_IdMedico",
                table: "Citas");

            migrationBuilder.AlterColumn<int>(
                name: "IdMedico",
                table: "Citas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Medicos_IdMedico",
                table: "Citas",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
