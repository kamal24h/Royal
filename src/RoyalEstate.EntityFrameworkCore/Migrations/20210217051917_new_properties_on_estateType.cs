using Microsoft.EntityFrameworkCore.Migrations;

namespace RoyalEstate.Migrations
{
    public partial class new_properties_on_estateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LegalDoc",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MasterRoom",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            //insert data to new columns
            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] {"LegalDoc", "MasterRoom"},
                new object[] {true, true});
            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LegalDoc", "MasterRoom" },
                new object[] { true, true });
            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LegalDoc", "MasterRoom" },
                new object[] { true, false });
            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LegalDoc", "MasterRoom" },
                new object[] { true, false });
            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "LegalDoc", "MasterRoom" },
                new object[] { false, true });
            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "LegalDoc", "MasterRoom" },
                new object[] { false, true });
            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "LegalDoc", "MasterRoom" },
                new object[] { false, false });
            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "LegalDoc", "MasterRoom" },
                new object[] { false, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LegalDoc",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "MasterRoom",
                table: "EstateTypes");
        }
    }
}
