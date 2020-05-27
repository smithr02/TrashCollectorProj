using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class addedCustomersSuspendStartDateEndDateDisplaysForEverything : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2bd43fc-dfa2-4829-99de-c351d454aa33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9db57a7-4363-48c2-a932-847d0c7e22b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efca7766-a3c4-4cb4-bde7-589c7a586af9");

            migrationBuilder.AddColumn<int>(
                name: "AnotherCollectionDay",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Customers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CollectionDay",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmExtraPickUpDate",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmPickupDate",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Customers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Balance",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CollectionDay",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ConfirmExtraPickUpDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ConfirmPickupDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efca7766-a3c4-4cb4-bde7-589c7a586af9", "b8dd95c2-3c6d-42c8-832e-66ef2c807b68", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9db57a7-4363-48c2-a932-847d0c7e22b4", "a34c58c5-aad1-4621-981e-3847294da7e8", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2bd43fc-dfa2-4829-99de-c351d454aa33", "6f8a8438-e553-41b0-a20a-078e87128b33", "Employee", "EMPLOYEE" });
        }
    }
}
