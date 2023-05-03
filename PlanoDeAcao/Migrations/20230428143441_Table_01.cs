using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanoDeAcao.Migrations
{
    public partial class Table_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parecer_Visita_VisitasId",
                table: "Parecer");

            migrationBuilder.DropIndex(
                name: "IX_Parecer_VisitasId",
                table: "Parecer");

            migrationBuilder.DropColumn(
                name: "VisitasId",
                table: "Parecer");

            migrationBuilder.AddColumn<int>(
                name: "VisitaId",
                table: "Parecer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parecer_VisitaId",
                table: "Parecer",
                column: "VisitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parecer_Visita_VisitaId",
                table: "Parecer",
                column: "VisitaId",
                principalTable: "Visita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parecer_Visita_VisitaId",
                table: "Parecer");

            migrationBuilder.DropIndex(
                name: "IX_Parecer_VisitaId",
                table: "Parecer");

            migrationBuilder.DropColumn(
                name: "VisitaId",
                table: "Parecer");

            migrationBuilder.AddColumn<int>(
                name: "VisitasId",
                table: "Parecer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parecer_VisitasId",
                table: "Parecer",
                column: "VisitasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parecer_Visita_VisitasId",
                table: "Parecer",
                column: "VisitasId",
                principalTable: "Visita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
