using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af680b95-2a36-463d-8653-ab0fc6d69f98",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4be637b6-3172-4f52-85ee-fbf693fb7962", new DateOnly(1990, 12, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEH9VcoF0MUusQ5gm1jRZZiUgRrNLkhDPgFjilDksASUejp504AfaYIPbFOy0bCg6BQ==", "c698e281-16b5-46ab-b951-264218387f4c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af680b95-2a36-463d-8653-ab0fc6d69f98",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07bf17b1-5e7c-418f-a6cd-824d48625c89", "AQAAAAIAAYagAAAAEEWiW6DHPJ5OCUArGl9uDD/fdDw08gCdBvz/akOrEqdhu2uZ8sNvp0/Z+u5CzwJbrQ==", "e9b82bf0-aefb-47ca-bdd6-c816bc064451" });
        }
    }
}
