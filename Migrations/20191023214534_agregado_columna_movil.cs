using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class agregado_columna_movil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Movil",
                table: "Citas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Movil",
                table: "Citas");
        }
    }
}
