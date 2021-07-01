using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class SomeDataTypechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Teachers_TeacherId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Skills",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Percent",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Teachers_TeacherId",
                table: "Skills",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Teachers_TeacherId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Percent",
                table: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Skills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Degree",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Teachers_TeacherId",
                table: "Skills",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
