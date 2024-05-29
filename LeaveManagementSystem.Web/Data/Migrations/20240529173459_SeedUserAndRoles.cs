using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "059ff44e-6f91-4cb4-9c7c-e85be3326c7c", null, "Administrator", "ADMINISTRATOR" },
                    { "2e02a921-c40b-47b8-8c3c-91749113f863", null, "Supervisor", "SUPERVISOR" },
                    { "d3b38299-e30c-4cac-8b81-f816aa5f1ef9", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "af680b95-2a36-463d-8653-ab0fc6d69f98", 0, "07bf17b1-5e7c-418f-a6cd-824d48625c89", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEEWiW6DHPJ5OCUArGl9uDD/fdDw08gCdBvz/akOrEqdhu2uZ8sNvp0/Z+u5CzwJbrQ==", null, false, "e9b82bf0-aefb-47ca-bdd6-c816bc064451", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "059ff44e-6f91-4cb4-9c7c-e85be3326c7c", "af680b95-2a36-463d-8653-ab0fc6d69f98" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e02a921-c40b-47b8-8c3c-91749113f863");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3b38299-e30c-4cac-8b81-f816aa5f1ef9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "059ff44e-6f91-4cb4-9c7c-e85be3326c7c", "af680b95-2a36-463d-8653-ab0fc6d69f98" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "059ff44e-6f91-4cb4-9c7c-e85be3326c7c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af680b95-2a36-463d-8653-ab0fc6d69f98");
        }
    }
}
