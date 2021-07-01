using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class NewMigrationCreatedForRequestErroFixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    UserName = table.Column<string>(maxLength: 200, nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AppUserId",
                table: "Requests",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CourseId",
                table: "Requests",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
