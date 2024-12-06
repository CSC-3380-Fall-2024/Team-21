using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiger_Tasks.Migrations
{
    /// <inheritdoc />
    public partial class ForumPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPost_AspNetUsers_UserId",
                table: "ForumPost");

            migrationBuilder.DropIndex(
                name: "IX_ForumPost_UserId",
                table: "ForumPost");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "ForumPost");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "ForumPost");

            migrationBuilder.DropColumn(
                name: "PostType",
                table: "ForumPost");

            migrationBuilder.DropColumn(
                name: "SelectedPostType",
                table: "ForumPost");

            migrationBuilder.DropColumn(
                name: "SelectedServiceType",
                table: "ForumPost");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ForumPost");

            migrationBuilder.RenameColumn(
                name: "ServiceType",
                table: "ForumPost",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ForumPost",
                newName: "ServiceType");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "ForumPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "ForumPost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PostType",
                table: "ForumPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SelectedPostType",
                table: "ForumPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SelectedServiceType",
                table: "ForumPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ForumPost",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForumPost_UserId",
                table: "ForumPost",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPost_AspNetUsers_UserId",
                table: "ForumPost",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
