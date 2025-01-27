using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleMigrations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87e55637-05ef-45e1-8eb9-d881cdefa88b", null, "", "Root", "ROOT" },
                    { "8d1348e5-a2c7-4a7a-8cb4-b7ccb2d2b9c9", null, "", "Admin", "ADMIN" },
                    { "d2bdbfba-77b1-40f5-b00d-3c4704154589", null, "", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastNAme", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6f41b021-3b66-484f-a673-7596f9c1aa07", 0, "e00c7e5c-67e3-4ea8-a09a-0436f73dbe0e", "root@root.com", false, "Admin", "Root", false, null, "ROOT@ROOT.COM", "ROOT", "AQAAAAIAAYagAAAAEFyE3FnOU0KNSKZD9N24Nm6mnPi+1aqEtxb/4tETI4PF4aPzzghWfBTpXMZuiCjOpw==", null, false, "e8a76447-cad7-4f9e-8b0c-c08f29b28e98", false, "Root" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "87e55637-05ef-45e1-8eb9-d881cdefa88b", "6f41b021-3b66-484f-a673-7596f9c1aa07" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d1348e5-a2c7-4a7a-8cb4-b7ccb2d2b9c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2bdbfba-77b1-40f5-b00d-3c4704154589");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "87e55637-05ef-45e1-8eb9-d881cdefa88b", "6f41b021-3b66-484f-a673-7596f9c1aa07" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87e55637-05ef-45e1-8eb9-d881cdefa88b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f41b021-3b66-484f-a673-7596f9c1aa07");
        }
    }
}
