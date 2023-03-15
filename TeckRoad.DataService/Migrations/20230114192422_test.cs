using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeckRoad.DataService.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoryItem_Category_CategoryId",
                table: "categoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_categoryItem_MediaType_MediaTypeId",
                table: "categoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_content_categoryItem_CategoryItemId",
                table: "content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_content",
                table: "content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoryItem",
                table: "categoryItem");

            migrationBuilder.RenameTable(
                name: "content",
                newName: "Content");

            migrationBuilder.RenameTable(
                name: "categoryItem",
                newName: "CategoryItem");

            migrationBuilder.RenameIndex(
                name: "IX_content_CategoryItemId",
                table: "Content",
                newName: "IX_Content_CategoryItemId");

            migrationBuilder.RenameIndex(
                name: "IX_categoryItem_MediaTypeId",
                table: "CategoryItem",
                newName: "IX_CategoryItem_MediaTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_categoryItem_CategoryId",
                table: "CategoryItem",
                newName: "IX_CategoryItem_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryItem",
                table: "CategoryItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItem_Category_CategoryId",
                table: "CategoryItem",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItem_MediaType_MediaTypeId",
                table: "CategoryItem",
                column: "MediaTypeId",
                principalTable: "MediaType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Content_CategoryItem_CategoryItemId",
                table: "Content",
                column: "CategoryItemId",
                principalTable: "CategoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItem_Category_CategoryId",
                table: "CategoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItem_MediaType_MediaTypeId",
                table: "CategoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Content_CategoryItem_CategoryItemId",
                table: "Content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryItem",
                table: "CategoryItem");

            migrationBuilder.RenameTable(
                name: "Content",
                newName: "content");

            migrationBuilder.RenameTable(
                name: "CategoryItem",
                newName: "categoryItem");

            migrationBuilder.RenameIndex(
                name: "IX_Content_CategoryItemId",
                table: "content",
                newName: "IX_content_CategoryItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryItem_MediaTypeId",
                table: "categoryItem",
                newName: "IX_categoryItem_MediaTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryItem_CategoryId",
                table: "categoryItem",
                newName: "IX_categoryItem_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_content",
                table: "content",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoryItem",
                table: "categoryItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_categoryItem_Category_CategoryId",
                table: "categoryItem",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categoryItem_MediaType_MediaTypeId",
                table: "categoryItem",
                column: "MediaTypeId",
                principalTable: "MediaType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_content_categoryItem_CategoryItemId",
                table: "content",
                column: "CategoryItemId",
                principalTable: "categoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
