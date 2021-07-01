using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class SettingsTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionNumber = table.Column<string>(maxLength: 20, nullable: true),
                    HeaderLogo = table.Column<string>(maxLength: 100, nullable: true),
                    FooterLogo = table.Column<string>(maxLength: 100, nullable: true),
                    FooterText = table.Column<string>(maxLength: 150, nullable: true),
                    FacebookUrl = table.Column<string>(maxLength: 100, nullable: true),
                    PinterestUrl = table.Column<string>(maxLength: 100, nullable: true),
                    VimeUrl = table.Column<string>(maxLength: 100, nullable: true),
                    TwitterUrl = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber1 = table.Column<string>(maxLength: 20, nullable: true),
                    PhoneNumber2 = table.Column<string>(maxLength: 20, nullable: true),
                    Mail = table.Column<string>(maxLength: 20, nullable: true),
                    WebSite = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
