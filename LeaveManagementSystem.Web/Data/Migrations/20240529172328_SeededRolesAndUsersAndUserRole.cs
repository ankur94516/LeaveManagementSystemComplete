using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededRolesAndUsersAndUserRole : Migration
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
                values: new object[] { "af680b95-2a36-463d-8653-ab0fc6d69f98", 0, "f11f1f89-e5af-4d94-b841-ade000cb8c42", "admin@localhost.com", false, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEAUDeC+kNviYoWu9nB9iTaoj+aXSkO90awyqbqW+xiVQDbqif5nZhUi7FmXlWispIg==", null, false, "3897f09a-b45b-4c5b-ba94-03c9f71a30bd", false, "admin@localhost.com" });

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
