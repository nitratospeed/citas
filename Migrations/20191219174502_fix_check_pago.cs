using Microsoft.EntityFrameworkCore.Migrations;

namespace citas.Migrations
{
    public partial class fix_check_pago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pago",
                table: "Citas",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Pago",
                table: "Citas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
