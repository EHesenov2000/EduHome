using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class SomeRelatioIdsChangedToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoticeBoardItems_NoticeBoards_NoticeBoardId",
                table: "NoticeBoardItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Teachers_TeacherId",
                table: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Skills",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NoticeBoardId",
                table: "NoticeBoardItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_NoticeBoardItems_NoticeBoards_NoticeBoardId",
                table: "NoticeBoardItems",
                column: "NoticeBoardId",
                principalTable: "NoticeBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Teachers_TeacherId",
                table: "Skills",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoticeBoardItems_NoticeBoards_NoticeBoardId",
                table: "NoticeBoardItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Teachers_TeacherId",
                table: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Skills",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NoticeBoardId",
                table: "NoticeBoardItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NoticeBoardItems_NoticeBoards_NoticeBoardId",
                table: "NoticeBoardItems",
                column: "NoticeBoardId",
                principalTable: "NoticeBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Teachers_TeacherId",
                table: "Skills",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
