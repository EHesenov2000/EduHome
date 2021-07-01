using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class NoticeBoardSectionTablesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoticeBoards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoticeBoardItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 200, nullable: true),
                    NoticeBoardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeBoardItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoticeBoardItems_NoticeBoards_NoticeBoardId",
                        column: x => x.NoticeBoardId,
                        principalTable: "NoticeBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoticeBoardItems_NoticeBoardId",
                table: "NoticeBoardItems",
                column: "NoticeBoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoticeBoardItems");

            migrationBuilder.DropTable(
                name: "NoticeBoards");
        }
    }
}
