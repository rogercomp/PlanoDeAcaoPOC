using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanoDeAcao.Migrations
{
    public partial class Table_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visita_Cliente_ClienteId",
                table: "Visita");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Visita",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visita_Cliente_ClienteId",
                table: "Visita",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visita_Cliente_ClienteId",
                table: "Visita");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Visita",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Visita_Cliente_ClienteId",
                table: "Visita",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
