using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shortener.Migrations
{
    /// <inheritdoc />
    public partial class RemovedShortCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_ShortCode",
                table: "ShortUrls");

            migrationBuilder.DropColumn(
                name: "ShortCode",
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

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_OriginalUrl",
                table: "ShortUrls",
                column: "OriginalUrl",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShortUrls_AspNetUsers_AppUser",
                table: "ShortUrls",
                column: "AppUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShortUrls_AspNetUsers_AppUser",
                table: "ShortUrls");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_AppUser",
                table: "ShortUrls");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_OriginalUrl",
                table: "ShortUrls");

            migrationBuilder.DropColumn(
                name: "AppUser",
                table: "ShortUrls");

            migrationBuilder.AddColumn<string>(
                name: "ShortCode",
                table: "ShortUrls",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_ShortCode",
                table: "ShortUrls",
                column: "ShortCode",
                unique: true);
        }
    }
}
