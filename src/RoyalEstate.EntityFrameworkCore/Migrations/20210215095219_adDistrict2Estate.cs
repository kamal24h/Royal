using Microsoft.EntityFrameworkCore.Migrations;

namespace RoyalEstate.Migrations
{
    public partial class adDistrict2Estate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Estates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_DistrictId",
                table: "Estates",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_District_DistrictId",
                table: "Estates",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_District_DistrictId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_DistrictId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Estates");
        }
    }
}
