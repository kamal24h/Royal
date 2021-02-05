using Microsoft.EntityFrameworkCore.Migrations;

namespace RoyalEstate.Migrations
{
    public partial class elevator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Elevator",
                table: "Estates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elevator",
                table: "Estates");
        }
    }
}
