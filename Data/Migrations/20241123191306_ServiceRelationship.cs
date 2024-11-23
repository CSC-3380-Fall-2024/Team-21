using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiger_Tasks.Data.Migrations
{
    /// <inheritdoc />
    public partial class ServiceRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_UserId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_UserId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Services",
                newName: "ServiceId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Services",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProviderUserId",
                table: "Services",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ApplicationUserId",
                table: "Services",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProviderUserId",
                table: "Services",
                column: "ProviderUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_ApplicationUserId",
                table: "Services",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_ProviderUserId",
                table: "Services",
                column: "ProviderUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_ApplicationUserId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_ProviderUserId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ApplicationUserId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ProviderUserId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ProviderUserId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Services",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Services",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId",
                table: "Services",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_UserId",
                table: "Services",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
