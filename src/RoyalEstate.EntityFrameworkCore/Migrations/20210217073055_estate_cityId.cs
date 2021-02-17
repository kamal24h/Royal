using Microsoft.EntityFrameworkCore.Migrations;

namespace RoyalEstate.Migrations
{
    public partial class estate_cityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Estates",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_CityId",
                table: "Estates",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_Cities_CityId",
                table: "Estates",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_Cities_CityId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_CityId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Estates");
        }
    }
}
