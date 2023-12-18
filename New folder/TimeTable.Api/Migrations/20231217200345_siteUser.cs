using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTable.Api.Migrations
{
    public partial class siteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b1f5ea6-5564-4f0b-8738-81a025d427c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35fb1668-5d1c-470e-927d-d6fe71b6ed08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d28fa00a-1ba5-4d3d-9608-5516f218c669");

            migrationBuilder.CreateTable(
                name: "SiteUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d52e273-cbc7-4664-88bc-ca8ceaabb2cf", "b76c2716-c1df-4733-ad8a-60c406c73b10", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a4a46ed-1368-4b6d-aed9-b4d188bdb93e", "c9e62d80-bc31-4422-bf26-e27355cd6230", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4526829-3cf7-4e85-97ed-694d44cfed15", "b3686aec-6afc-4e05-bdac-5b2784668c74", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d52e273-cbc7-4664-88bc-ca8ceaabb2cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a4a46ed-1368-4b6d-aed9-b4d188bdb93e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4526829-3cf7-4e85-97ed-694d44cfed15");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b1f5ea6-5564-4f0b-8738-81a025d427c0", "9ccc329e-8cfa-42fc-81af-ba190e4d4dc1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35fb1668-5d1c-470e-927d-d6fe71b6ed08", "3fd48e73-c284-4eb1-88eb-41e85bf9ae9b", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d28fa00a-1ba5-4d3d-9608-5516f218c669", "bb8bb48d-49e8-41c6-8463-8a17796ec9b6", "Admin", "ADMIN" });
        }
    }
}
