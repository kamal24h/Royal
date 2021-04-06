using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoyalEstate.Migrations
{
    public partial class EstateTypeColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "EstateTypes",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData("EstateTypes",
                "Id",
                new object[] {1, 2, 3, 4, 5, 6, 7, 8},
                "Color",
                new object[] {"Green", "Green", "Green", "Green", "Yellow", "Yellow", "Yellow", "Yellow" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "EstateTypes");
        }
    }
}
