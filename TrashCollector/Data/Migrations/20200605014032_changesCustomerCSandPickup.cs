using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class changesCustomerCSandPickup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37bacf6e-810d-4838-932d-6bd2a3a0690c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a02acef-137d-4715-9b0c-5179986a6e2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae45c5f0-a487-4979-9439-b1e04cd18687");

            migrationBuilder.DropColumn(
                name: "AnotherCollectionDay",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ConfirmExtraPickUpDate",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "PickUps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUps", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9a66615f-90da-4211-9db8-8af1de0824c7", "32e2f5f3-d632-4bfc-8b8e-c7093f8ef0e6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08a581b5-d050-4167-af60-58ba31084539", "98844228-b505-4cfb-9244-9c9df50b381a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9df07b7-e7ec-4fd6-aa3a-accaf2ae37b4", "650cf6b7-50a0-472f-9715-3ea5f24ef199", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PickUps");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08a581b5-d050-4167-af60-58ba31084539");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a66615f-90da-4211-9db8-8af1de0824c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9df07b7-e7ec-4fd6-aa3a-accaf2ae37b4");

            migrationBuilder.AddColumn<int>(
                name: "AnotherCollectionDay",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmExtraPickUpDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a02acef-137d-4715-9b0c-5179986a6e2e", "7201b2e8-27cd-4c93-ace1-b0ed6720bce8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37bacf6e-810d-4838-932d-6bd2a3a0690c", "09db14a0-c189-49d4-adcc-cf44db3d2e40", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae45c5f0-a487-4979-9439-b1e04cd18687", "8910781d-2a57-488a-ab54-c1f7a46e5239", "Employee", "EMPLOYEE" });
        }
    }
}
