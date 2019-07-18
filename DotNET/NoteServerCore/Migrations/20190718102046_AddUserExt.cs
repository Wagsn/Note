using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteServer.Migrations
{
    public partial class AddUserExt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserExts",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    UserId = table.Column<string>(maxLength: 36, nullable: true),
                    RealName = table.Column<string>(maxLength: 63, nullable: true),
                    Gender = table.Column<bool>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 63, nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    IdNumber = table.Column<string>(maxLength: 31, nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    PostBox = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExts");
        }
    }
}
