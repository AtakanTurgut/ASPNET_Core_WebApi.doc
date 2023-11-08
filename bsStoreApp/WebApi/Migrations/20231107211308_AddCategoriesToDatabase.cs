using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddCategoriesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81df00c5-7e90-46f6-985d-754cf7dfb6ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a983994-576d-48e0-a2c4-08d306314de1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffcdd37b-0690-4944-a82f-b1c39a01bbe9");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64b9fafb-42e4-4170-a70d-ae52dd838d59", "88915bec-4777-4c31-93c1-e74f3f1a8edc", "Editor", "EDITOR" },
                    { "83c9a4f1-485d-4fe3-bd76-eddedf85c27e", "57ed344c-44da-48f3-a147-3fe59bd527fb", "Admin", "ADMIN" },
                    { "bddb1072-b117-4e25-9565-54296566cb17", "66c39fc1-26aa-4f59-a886-f817e7adac2b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Network" },
                    { 3, "Database Management Systems" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b9fafb-42e4-4170-a70d-ae52dd838d59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83c9a4f1-485d-4fe3-bd76-eddedf85c27e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bddb1072-b117-4e25-9565-54296566cb17");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81df00c5-7e90-46f6-985d-754cf7dfb6ba", "e871556c-faae-4af1-ba54-244113ea255d", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a983994-576d-48e0-a2c4-08d306314de1", "b421547d-7ce1-4c19-bdc8-2dc2553c17ec", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffcdd37b-0690-4944-a82f-b1c39a01bbe9", "d3dabb41-38e1-4d96-a50d-4a53052cf0e9", "Admin", "ADMIN" });
        }
    }
}
