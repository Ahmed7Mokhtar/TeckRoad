using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;
using TeckRoad.Entities.DbSets;

#nullable disable

namespace TeckRoad.DataService.Migrations
{
    public partial class addAdminAccount : Migration
    {
        const string ADMIN_USER_GUID = "403b5421-7f81-4753-b8d1-4fc7fce73e82";
        const string ADMIN_ROLE_GUID = "197dafc5-72eb-435e-91a4-931b32dc14a8";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_CategoryItem_CategoryItemId",
                table: "Content");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryItemId",
                table: "Content",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_CategoryItem_CategoryItemId",
                table: "Content",
                column: "CategoryItemId",
                principalTable: "CategoryItem",
                principalColumn: "Id");

            var hasher = new PasswordHasher<AppUser>();

            var password = hasher.HashPassword(null, "Password100!");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, NormalizedEmail, PasswordHash, SecurityStamp, FirstName)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{ADMIN_USER_GUID}'");
            sb.AppendLine(", 'ahmed@teckroad.com'");
            sb.AppendLine(", 'AHMED@TECKROAD.COM'");
            sb.AppendLine(", 'ahmed@teckroad.com'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 'AHMED@TECKROAD.COM'");
            sb.AppendLine($", '{password}'");
            sb.AppendLine(", ''");
            sb.AppendLine(", 'Admin'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{ADMIN_ROLE_GUID}', 'Admin', 'ADMIN')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{ADMIN_USER_GUID}', '{ADMIN_ROLE_GUID}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_CategoryItem_CategoryItemId",
                table: "Content");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryItemId",
                table: "Content",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Content_CategoryItem_CategoryItemId",
                table: "Content",
                column: "CategoryItemId",
                principalTable: "CategoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{ADMIN_USER_GUID}' AND RoleId = '{ADMIN_ROLE_GUID}'");


            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = '{ADMIN_USER_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{ADMIN_ROLE_GUID}'");

        }
    }
}
