using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RusMProject.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Mi20230202 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExceptionNotifications",
                columns: new[] { "Id", "CreatorDate", "CreatorUserId", "Description", "EditorDate", "EditorUserId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5034), 1, "There is no data available corresponding this request", null, null, true, "Not Found" },
                    { 2, new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5080), 1, "The request the you made is incorrect or corrupt", null, null, true, "Bad Request" },
                    { 3, new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5083), 1, "An error occurred on the server", null, null, true, "Server Error" },
                    { 4, new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5085), 1, "Data is must not null,zero or empty", null, null, true, "Client Error" },
                    { 5, new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5089), 1, "No matching language found", null, null, true, "Client Error For Lang" },
                    { 6, new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5093), 1, "There is no data in the database that matches the given language", null, null, true, "Not Found For Language" },
                    { 7, new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5095), 1, "The given language does not exist in the databases", null, null, true, "Server Error Parent Child" },
                    { 8, new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5098), 1, "There is no word in the database that matches the given id", null, null, true, "Not Found For Id" },
                    { 9, new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5100), 1, "There is no data in the database that matches the given language or id", null, null, true, "Not Found For Language Or Id" },
                    { 10, new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5104), 1, "The given language does not exist in the databases", null, null, true, "Client Error For Model" },
                    { 11, new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5106), 1, "AuthenticationToken Is Required", null, null, true, "AuthenticationTokenIsRequired" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExceptionNotifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExceptionNotifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExceptionNotifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExceptionNotifications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExceptionNotifications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExceptionNotifications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExceptionNotifications",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ExceptionNotifications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExceptionNotifications",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ExceptionNotifications",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ExceptionNotifications",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
