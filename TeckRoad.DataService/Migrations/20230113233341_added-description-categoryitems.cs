using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeckRoad.DataService.Migrations
{
    public partial class addeddescriptioncategoryitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "categoryItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "categoryItem");
        }
    }
}
