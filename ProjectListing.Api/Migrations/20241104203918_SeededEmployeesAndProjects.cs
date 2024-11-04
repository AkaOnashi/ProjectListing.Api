using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectListing.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeededEmployeesAndProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Last_Name", "Name", "Position", "Status", "Subdivision" },
                values: new object[,]
                {
                    { 1, "Anko", "Ava", "Designer", "Active", "Design Team" },
                    { 2, "Benko", "Bab", ".NET Developer", "Active", "Dev Team" },
                    { 3, "Cenko", "Cava", "Project Manager", "Active", "Managment" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, "To do some \"A\" things", new DateTime(2025, 1, 4, 22, 39, 14, 370, DateTimeKind.Local).AddTicks(7042), "Project A", new DateTime(2024, 11, 4, 22, 39, 14, 370, DateTimeKind.Local).AddTicks(6997), "Active" },
                    { 2, "To do some \"B\" things very seriously", new DateTime(2024, 12, 4, 22, 39, 14, 370, DateTimeKind.Local).AddTicks(7052), "Project B", new DateTime(2024, 11, 4, 22, 39, 14, 370, DateTimeKind.Local).AddTicks(7050), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProjects",
                columns: new[] { "Id_Employee", "Id_Project" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "Id_Employee", "Id_Project" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "Id_Employee", "Id_Project" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "Id_Employee", "Id_Project" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
