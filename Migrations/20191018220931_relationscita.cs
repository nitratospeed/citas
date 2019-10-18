using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class relationscita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdMedico",
                table: "Citas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdMedico",
                table: "Citas",
                column: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Medicos_IdMedico",
                table: "Citas",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Medicos_IdMedico",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_IdMedico",
                table: "Citas");

            migrationBuilder.AlterColumn<int>(
                name: "IdMedico",
                table: "Citas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
