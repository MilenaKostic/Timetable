using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTable.Api.Migrations
{
    public partial class Auth2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3854932d-83b4-46a3-8cf9-7d068eeca695", "aa3526f2-4053-4837-8ea8-ca06d27af69d", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58cdeabc-dbb2-499b-8c74-5b7c56298fce", "012a607a-88dc-4dbb-83ad-07cfc8fef12a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cbbab2a8-ed77-439c-98ed-7ebb86fa68c3", "be1ecfa9-fb78-4eb2-8098-a0161d6365b0", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3854932d-83b4-46a3-8cf9-7d068eeca695");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58cdeabc-dbb2-499b-8c74-5b7c56298fce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbbab2a8-ed77-439c-98ed-7ebb86fa68c3");
        }
    }
}
