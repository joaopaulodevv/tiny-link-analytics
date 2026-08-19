using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shortener.Migrations
{
    /// <inheritdoc />
    public partial class OwnerFkFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShortUrls_AspNetUsers_AppUser",
                table: "ShortUrls");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_AppUser",
                table: "ShortUrls");

            migrationBuilder.DropColumn(
                name: "AppUser",
                table: "ShortUrls");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "ShortUrls",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_OwnerId",
                table: "ShortUrls",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShortUrls_AspNetUsers_OwnerId",
                table: "ShortUrls",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShortUrls_AspNetUsers_OwnerId",
                table: "ShortUrls");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_OwnerId",
                table: "ShortUrls");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ShortUrls");

            migrationBuilder.AddColumn<string>(
                name: "AppUser",
                table: "ShortUrls",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_AppUser",
                table: "ShortUrls",
                column: "AppUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ShortUrls_AspNetUsers_AppUser",
                table: "ShortUrls",
                column: "AppUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
