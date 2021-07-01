using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class NoticeBoardTableDeletedAndVideoUrlAddedToSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Courses_CourseId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_NoticeBoardItems_NoticeBoards_NoticeBoardId",
                table: "NoticeBoardItems");

            migrationBuilder.DropTable(
                name: "NoticeBoards");

            migrationBuilder.DropIndex(
                name: "IX_NoticeBoardItems_NoticeBoardId",
                table: "NoticeBoardItems");

            migrationBuilder.DropColumn(
                name: "NoticeBoardId",
                table: "NoticeBoardItems");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Settings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Features",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Courses_CourseId",
                table: "Features",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Courses_CourseId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Settings");

            migrationBuilder.AddColumn<int>(
                name: "NoticeBoardId",
                table: "NoticeBoardItems",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Features",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "NoticeBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeBoards", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoticeBoardItems_NoticeBoardId",
                table: "NoticeBoardItems",
                column: "NoticeBoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Courses_CourseId",
                table: "Features",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NoticeBoardItems_NoticeBoards_NoticeBoardId",
                table: "NoticeBoardItems",
                column: "NoticeBoardId",
                principalTable: "NoticeBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
