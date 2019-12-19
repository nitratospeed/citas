using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class check_pago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pago",
                table: "Citas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Citas");
        }
    }
}
