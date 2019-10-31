using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class fix_models13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdTipo",
                table: "Citas",
                column: "IdTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Tipo_IdTipo",
                table: "Citas",
                column: "IdTipo",
                principalTable: "Tipo",
                principalColumn: "IdTipo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Tipo_IdTipo",
                table: "Citas");


            migrationBuilder.DropIndex(
                name: "IX_Citas_IdTipo",
                table: "Citas");
        }
    }
}
