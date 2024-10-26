using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiger_Tasks.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServicesNeeded",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServicesProvided",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicesNeeded",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ServicesProvided",
                table: "AspNetUsers");
        }
    }
}
