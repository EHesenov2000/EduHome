using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class SomeChangesSkillAndTeacherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkypeName",
                table: "Skills");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teachers",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Teachers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkypeName",
                table: "Teachers",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SkypeName",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Skills",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Skills",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkypeName",
                table: "Skills",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
