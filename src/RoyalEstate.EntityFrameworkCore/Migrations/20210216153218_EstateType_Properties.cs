using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RoyalEstate.Migrations
{
    public partial class EstateType_Properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Area",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BuiltDate",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deposit",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Elevator",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Floor",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Parking",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Price",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Rent",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Rooms",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);            

            migrationBuilder.AddColumn<bool>(
                name: "Storeroom",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TotalFloors",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UnitsPerFloor",
                table: "EstateTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "EstateTypes",
                nullable: false,
                defaultValue: 0);

            #region Update Service Types

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "ResidentialForSale");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "ResidentialForRent");

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id","Name", "IsActive" },
                values: new object[] {3, "CommercialForSale", true });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] {"Id", "Name", "IsActive" },
                values: new object[] {4, "CommercialForRent", true });

            #endregion


            #region Update Current Estate Types

            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ServiceTypeId", 
                    "Name",
                    "Price", "Rent", "Deposit",
                    "Area", "Rooms", "Floor", "TotalFloors", "UnitsPerFloor",
                    "Parking", "Storeroom", "Elevator","BuiltDate" },
                values: new object[] { 1, 
                    "ApartmentForSale",
                    true,false,false,
                    true, true, true, true, true,
                    true, true, true, true
                });

            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ServiceTypeId",
                    "Name",
                    "Price", "Rent", "Deposit",
                    "Area", "Rooms", "Floor", "TotalFloors", "UnitsPerFloor",
                    "Parking", "Storeroom", "Elevator","BuiltDate" },
                values: new object[] { 1, 
                    "HomeForSale",
                    true,false,false,
                    true, true, false, false, false,
                    true, true, false, true
                });

            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ServiceTypeId",
                    "Name",
                    "Price", "Rent", "Deposit",
                    "Area", "Rooms", "Floor", "TotalFloors", "UnitsPerFloor",
                    "Parking", "Storeroom", "Elevator","BuiltDate" },
                values: new object[] { 3, 
                    "StoreForSale",
                    true,false,false,
                    true, false, false, false, false,
                    true, false, false, true
                });

            migrationBuilder.UpdateData(
                table: "EstateTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ServiceTypeId",
                    "Name",
                    "Price", "Rent", "Deposit",
                    "Area", "Rooms", "Floor", "TotalFloors", "UnitsPerFloor",
                    "Parking", "Storeroom", "Elevator","BuiltDate" },
                values: new object[] { 3, 
                    "OfficeForSale",
                    true,false,false,
                    true, true, false, false, false,
                    true, false, false, true
                });

            #endregion


            #region Insert New Estate Types

            migrationBuilder.InsertData(
                table: "EstateTypes",
                columns: new[] {"Id", "ServiceTypeId",
                    "Name",
                    "Price", "Rent", "Deposit",
                    "Area", "Rooms", "Floor", "TotalFloors", "UnitsPerFloor",
                    "Parking", "Storeroom", "Elevator","BuiltDate",
                    "CreationTime"
                },
                values: new object[] {5, 2,
                    "ApartmentForRent",
                    false,true,true,
                    true, true, true, true, true,
                    true, true, true, true,
                    DateTime.Now
                });

            migrationBuilder.InsertData(
                table: "EstateTypes",
                columns: new[] { "Id", "ServiceTypeId",
                    "Name",
                    "Price", "Rent", "Deposit",
                    "Area", "Rooms", "Floor", "TotalFloors", "UnitsPerFloor",
                    "Parking", "Storeroom", "Elevator","BuiltDate",
                    "CreationTime" },
                values: new object[] { 6, 2,
                    "HomeForRent",
                    false,true,true,
                    true, true, false, false, false,
                    true, true, false, true,
                    DateTime.Now
                });

            migrationBuilder.InsertData(
                table: "EstateTypes",
                columns: new[] { "Id", "ServiceTypeId",
                    "Name",
                    "Price", "Rent", "Deposit",
                    "Area", "Rooms", "Floor", "TotalFloors", "UnitsPerFloor",
                    "Parking", "Storeroom", "Elevator","BuiltDate",
                    "CreationTime" },
                values: new object[] {7, 4,
                    "StoreForRent",
                    false,true,true,
                    true, false, false, false, false,
                    true, false, false, true,
                    DateTime.Now
                });

            migrationBuilder.InsertData(
                table: "EstateTypes",
                columns: new[] { "Id", "ServiceTypeId",
                    "Name",
                    "Price", "Rent", "Deposit",
                    "Area", "Rooms", "Floor", "TotalFloors", "UnitsPerFloor",
                    "Parking", "Storeroom", "Elevator","BuiltDate",
                    "CreationTime" },
                values: new object[] {8, 4,
                    "OfficeForRent",
                    false,true,true,
                    true, true, false, false, false,
                    true, false, false, true,
                    DateTime.Now
                });

            #endregion

            migrationBuilder.CreateIndex(
                name: "IX_EstateTypes_ServiceTypeId",
                table: "EstateTypes",
                column: "ServiceTypeId");            

            migrationBuilder.AddForeignKey(
                name: "FK_EstateTypes_ServiceTypes_ServiceTypeId",
                table: "EstateTypes",
                column: "ServiceTypeId",                
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstateTypes_ServiceTypes_ServiceTypeId",
                table: "EstateTypes");

            migrationBuilder.DropIndex(
                name: "IX_EstateTypes_ServiceTypeId",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "BuiltDate",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "Elevator",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "Parking",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "Rent",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "Rooms",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "Storeroom",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "TotalFloors",
                table: "EstateTypes");

            migrationBuilder.DropColumn(
                name: "UnitsPerFloor",
                table: "EstateTypes");
        }
    }
}
