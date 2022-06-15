using Microsoft.EntityFrameworkCore.Migrations;

namespace Start_Bootstrap.Back_End.Migrations
{
    public partial class AboutIcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Abouts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Abouts");
        }
    }
}
