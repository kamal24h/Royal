using Microsoft.EntityFrameworkCore.Migrations;

namespace RoyalEstate.Migrations
{
    public partial class removed_serviceType_from_estates_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //update estateTypeId to reflect the correct estate types

            #region update estateTypeId in estates table

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumns: new[] { "ServiceTypeId", "EstateTypeId" },
                keyValues: new object[] { 1, 1 },
                column: "EstateTypeId",
                value: 1
            );
            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumns: new[] { "ServiceTypeId", "EstateTypeId" },
                keyValues: new object[] { 1, 2 },
                column: "EstateTypeId",
                value: 2
            );
            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumns: new[] { "ServiceTypeId", "EstateTypeId" },
                keyValues: new object[] { 1, 3 },
                column: "EstateTypeId",
                value: 3
            );
            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumns: new[] { "ServiceTypeId", "EstateTypeId" },
                keyValues: new object[] { 1, 4 },
                column: "EstateTypeId",
                value: 4
            );
            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumns: new[] { "ServiceTypeId", "EstateTypeId" },
                keyValues: new object[] { 2, 1 },
                column: "EstateTypeId",
                value: 5
            );
            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumns: new[] { "ServiceTypeId", "EstateTypeId" },
                keyValues: new object[] { 2, 2 },
                column: "EstateTypeId",
                value: 6
            );
            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumns: new[] { "ServiceTypeId", "EstateTypeId" },
                keyValues: new object[] { 2, 3 },
                column: "EstateTypeId",
                value: 7
            );
            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumns: new[] { "ServiceTypeId", "EstateTypeId" },
                keyValues: new object[] { 2, 4 },
                column: "EstateTypeId",
                value: 8
            );

            #endregion

            ///////////////

            migrationBuilder.DropForeignKey(
                name: "FK_Estates_ServiceTypes_ServiceTypeId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_ServiceTypeId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "Estates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "Estates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_ServiceTypeId",
                table: "Estates",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_ServiceTypes_ServiceTypeId",
                table: "Estates",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
