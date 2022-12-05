using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJWT_MySQL.Migrations
{
    public partial class Add_Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1B3D7E19-B1A5-4CA2-A491-54593FA16531",
                column: "ConcurrencyStamp",
                value: "da48a933-6f62-4264-84b4-799f4762f107");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "41b05c84-681e-4e30-b330-ad78d05d86a9");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Url", "UserId" },
                values: new object[,]
                {
                    { new Guid("597089e0-5148-4696-92fc-8aa252385722"), "https://lh3.googleusercontent.com/a/AEdFTp5O41syiiOXKyYwoNE8UWt4mp2GAszsgxyV3n_C=s317-p-rw-no", "70BD714F-9576-45BA-B5B7-F00649BE00DE" },
                    { new Guid("9adac76e-e9d0-4419-b2f9-182373b4be7b"), "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Stack_Overflow_icon.svg/768px-Stack_Overflow_icon.svg.png", "70BD714F-9576-45BA-B5B7-F00649BE00DE" },
                    { new Guid("c248c929-7e74-4f9f-a665-c0b377819691"), "https://upload.wikimedia.org/wikipedia/commons/0/0f/Pepsi_logo_2014.svg", "69BD714F-9576-45BA-B5B7-F00649BE00DE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1B3D7E19-B1A5-4CA2-A491-54593FA16531",
                column: "ConcurrencyStamp",
                value: "7af7dfed-4c1a-445f-bdb0-56f2fb4adabc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "2486bff5-eec2-4250-a2d0-4f5f4b6154c4");
        }
    }
}
