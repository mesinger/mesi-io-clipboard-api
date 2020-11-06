using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mesi.Io.Clipboard.Infrastructure.Db.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_clipboard_entries",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    user = table.Column<string>(maxLength: 40, nullable: false),
                    content = table.Column<string>(maxLength: 500, nullable: false),
                    time_stamp = table.Column<DateTime>(nullable: false),
                    content_max_length = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_clipboard_entries", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_clipboard_entries");
        }
    }
}
