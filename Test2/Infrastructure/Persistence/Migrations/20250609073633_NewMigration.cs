using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test2.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "Arina", "Liubas", null });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramId", "DurationMinutes", "Name", "TemperatureCelsius" },
                values: new object[,]
                {
                    { 1, 30, "Quick Wash", 40 },
                    { 2, 90, "Cotton Cycle", 60 },
                    { 3, 45, "Synthetic", 50 }
                });

            migrationBuilder.InsertData(
                table: "WashingMachines",
                columns: new[] { "WashingMachineId", "MaxWeight", "SerialNumber" },
                values: new object[] { 1, 15m, "a2" });

            migrationBuilder.InsertData(
                table: "AvailablePrograms",
                columns: new[] { "AvailableProgramId", "Price", "ProgramId", "WashingMachineId" },
                values: new object[] { 1, 1001m, 1, 1 });

            migrationBuilder.InsertData(
                table: "PurchaseHistories",
                columns: new[] { "AvailableProgramId", "CustomerId", "PurchaseDate", "Rating" },
                values: new object[] { 1, 1, new DateTime(2004, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PurchaseHistories",
                keyColumns: new[] { "AvailableProgramId", "CustomerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AvailablePrograms",
                keyColumn: "AvailableProgramId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WashingMachines",
                keyColumn: "WashingMachineId",
                keyValue: 1);
        }
    }
}
