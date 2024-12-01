using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiger_Tasks.Migrations
{
    /// <inheritdoc />
    public partial class ForumPostFiltering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostType",
                table: "ForumPost",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostType",
                table: "ForumPost");
        }
    }
}
