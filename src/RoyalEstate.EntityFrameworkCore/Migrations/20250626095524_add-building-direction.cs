using Microsoft.EntityFrameworkCore.Migrations;

namespace RoyalEstate.Migrations
{
    public partial class addbuildingdirection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BuildingDirection",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BuildingDirection",
                table: "Estates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingDirection",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "BuildingDirection",
                table: "Estates");
        }
    }
}
