using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class FeaturesTableColumnsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assesment",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "ClassDuration",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "CourseDuration",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "StudentsCount",
                table: "Features");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Features",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Features",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Features");

            migrationBuilder.AddColumn<string>(
                name: "Assesment",
                table: "Features",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ClassDuration",
                table: "Features",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CourseDuration",
                table: "Features",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Features",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkillLevel",
                table: "Features",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StudentsCount",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
