using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanoDeAcao.Migrations
{
    public partial class OtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParecerId",
                table: "ActionPlan",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visita_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parecer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parecer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parecer_Visita_VisitasId",
                        column: x => x.VisitasId,
                        principalTable: "Visita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlan_ParecerId",
                table: "ActionPlan",
                column: "ParecerId");

            migrationBuilder.CreateIndex(
                name: "IX_Parecer_VisitasId",
                table: "Parecer",
                column: "VisitasId");

            migrationBuilder.CreateIndex(
                name: "IX_Visita_ClienteId",
                table: "Visita",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlan_Parecer_ParecerId",
                table: "ActionPlan",
                column: "ParecerId",
                principalTable: "Parecer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlan_Parecer_ParecerId",
                table: "ActionPlan");

            migrationBuilder.DropTable(
                name: "Parecer");

            migrationBuilder.DropTable(
                name: "Visita");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_ActionPlan_ParecerId",
                table: "ActionPlan");

            migrationBuilder.DropColumn(
                name: "ParecerId",
                table: "ActionPlan");
        }
    }
}
