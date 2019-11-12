using Microsoft.EntityFrameworkCore.Migrations;

namespace Belt.Migrations
{
    public partial class initial113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlannerName",
                table: "Fiesta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannerName",
                table: "Fiesta");
        }
    }
}
