using Microsoft.EntityFrameworkCore.Migrations;

namespace RusMProject.Persistance.Migrations
{
    public partial class Mi20230201Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatorUserId",
                table: "Employees",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EditorUserId",
                table: "Employees",
                column: "EditorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatorUserId",
                table: "Departments",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_EditorUserId",
                table: "Departments",
                column: "EditorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_CreatorUserId",
                table: "Departments",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_EditorUserId",
                table: "Departments",
                column: "EditorUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_CreatorUserId",
                table: "Employees",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_EditorUserId",
                table: "Employees",
                column: "EditorUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_CreatorUserId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_EditorUserId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_CreatorUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_EditorUserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CreatorUserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EditorUserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CreatorUserId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_EditorUserId",
                table: "Departments");
        }
    }
}
