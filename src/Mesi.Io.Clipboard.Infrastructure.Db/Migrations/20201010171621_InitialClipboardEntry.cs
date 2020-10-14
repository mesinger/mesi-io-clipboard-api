using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mesi.Io.Clipboard.Infrastructure.Db.Migrations
{
    public partial class InitialClipboardEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clipboardEntries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    User = table.Column<string>(maxLength: 40, nullable: false),
                    Content = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ContentMaxLength = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clipboardEntries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clipboardEntries");
        }
    }
}
