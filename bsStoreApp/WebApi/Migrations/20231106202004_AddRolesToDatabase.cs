using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "229010ac-200a-4459-b7f7-95ead9f0b03d", "a34fe103-cd79-4bc3-8429-21c3804c2784", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "673fa485-c6fe-4593-8965-9507f1bd5008", "1569ffee-dbb8-4ba7-a261-25b9f5d1c06f", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5f6ee72-9ed8-476f-a79a-b2942796543c", "8838a255-9370-42c7-9565-978ce2977c03", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "229010ac-200a-4459-b7f7-95ead9f0b03d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "673fa485-c6fe-4593-8965-9507f1bd5008");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5f6ee72-9ed8-476f-a79a-b2942796543c");
        }
    }
}
