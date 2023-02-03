using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RusMProject.Persistance.Migrations
{
    public partial class Mi16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExceptionNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatorUser = table.Column<int>(type: "int", nullable: false),
                    CreatorDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditorUser = table.Column<int>(type: "int", nullable: true),
                    EditorDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionNotifications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExceptionNotifications");
        }
    }
}
