using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RusMProject.Persistance.Migrations
{
    public partial class Mi20230201Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SecretAnswer = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SecretQuestion = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CreatorUserId = table.Column<int>(type: "int", nullable: false),
                    CreatorDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditorUserId = table.Column<int>(type: "int", nullable: true),
                    EditorDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
