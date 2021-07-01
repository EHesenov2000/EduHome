using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class MigrationCreatedForClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
    }
}
