using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class added_duracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duracion",
                table: "Citas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracion",
                table: "Citas");
        }
    }
}
