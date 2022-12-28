using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webapp3.Migrations
{
    public partial class UserUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImageFilename",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,defaultValue: "No_Image.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageFilename",
                table: "Users");
        }
    }
}
