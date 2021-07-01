using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class SomeDataTypesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_AppUserId",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_AppUserId",
                table: "Requests",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_AppUserId",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_AppUserId",
                table: "Requests",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
