using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UCredential",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UCredential", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UProfile",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UProfile", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UProfile_UCredential_UserId",
                        column: x => x.UserId,
                        principalTable: "UCredential",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UCredential",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[] { 1, "john@tracker.com", "john1234", "Admin", "john" });

            migrationBuilder.InsertData(
                table: "UCredential",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[] { 2, "george@tracker.com", "goerge1234", "User", "george" });

            migrationBuilder.InsertData(
                table: "UCredential",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[] { 3, "thomas@tracker.com", "thomas1234", "User", "thomas" });

            migrationBuilder.InsertData(
                table: "UProfile",
                columns: new[] { "UserId", "Dob", "Name", "Sex" },
                values: new object[] { 1, new DateTime(1975, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick", "Male" });

            migrationBuilder.InsertData(
                table: "UProfile",
                columns: new[] { "UserId", "Dob", "Name", "Sex" },
                values: new object[] { 2, new DateTime(1982, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Stone", "Male" });

            migrationBuilder.InsertData(
                table: "UProfile",
                columns: new[] { "UserId", "Dob", "Name", "Sex" },
                values: new object[] { 3, new DateTime(1993, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thomas Anderson", "Male" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UProfile");

            migrationBuilder.DropTable(
                name: "UCredential");
        }
    }
}
