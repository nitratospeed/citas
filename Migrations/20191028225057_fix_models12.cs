using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace citas.Migrations
{
    public partial class fix_models12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    IdTipo = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.IdTipo);
                });

/*             migrationBuilder.CreateIndex(
                name: "IX_Citas_IdTipo",
                table: "Citas",
                column: "IdTipo"); */

/*             migrationBuilder.AddForeignKey(
                name: "FK_Citas_Tipo_IdTipo",
                table: "Citas",
                column: "IdTipo",
                principalTable: "Tipo",
                principalColumn: "IdTipo",
                onDelete: ReferentialAction.Cascade); */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
/*             migrationBuilder.DropForeignKey(
                name: "FK_Citas_Tipo_IdTipo",
                table: "Citas"); */

            migrationBuilder.DropTable(
                name: "Tipo");

/*             migrationBuilder.DropIndex(
                name: "IX_Citas_IdTipo",
                table: "Citas"); */
        }
    }
}
