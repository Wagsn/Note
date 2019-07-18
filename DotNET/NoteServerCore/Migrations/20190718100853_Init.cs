using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Title = table.Column<string>(maxLength: 127, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoteUserRelations",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 36, nullable: false),
                    NoteId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteUserRelations", x => new { x.NoteId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Email = table.Column<string>(maxLength: 3, nullable: false),
                    NickName = table.Column<string>(maxLength: 63, nullable: true),
                    Password = table.Column<string>(maxLength: 511, nullable: true),
                    AvatarUrl = table.Column<string>(maxLength: 1023, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "NoteUserRelations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
