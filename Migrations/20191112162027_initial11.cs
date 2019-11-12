using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Belt.Migrations
{
    public partial class initial11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fiesta",
                columns: table => new
                {
                    FiestaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlannerId = table.Column<int>(nullable: false),
                    Tittle = table.Column<string>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    Tiempo = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiesta", x => x.FiestaId);
                });

            migrationBuilder.CreateTable(
                name: "FiestaAndPlanner",
                columns: table => new
                {
                    FiestaAndPlannerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    FiestaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiestaAndPlanner", x => x.FiestaAndPlannerId);
                    table.ForeignKey(
                        name: "FK_FiestaAndPlanner_Fiesta_FiestaId",
                        column: x => x.FiestaId,
                        principalTable: "Fiesta",
                        principalColumn: "FiestaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FiestaAndPlanner_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FiestaAndPlanner_FiestaId",
                table: "FiestaAndPlanner",
                column: "FiestaId");

            migrationBuilder.CreateIndex(
                name: "IX_FiestaAndPlanner_UserId",
                table: "FiestaAndPlanner",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiestaAndPlanner");

            migrationBuilder.DropTable(
                name: "Fiesta");
        }
    }
}
