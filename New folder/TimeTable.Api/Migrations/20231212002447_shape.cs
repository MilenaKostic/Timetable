using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTable.Api.Migrations
{
    public partial class shape : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Shapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    RBr = table.Column<int>(type: "int", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shapes", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shapes");

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
    }
}
