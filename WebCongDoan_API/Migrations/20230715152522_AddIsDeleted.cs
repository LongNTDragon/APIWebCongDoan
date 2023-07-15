using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCongDoan_API.Migrations
{
    public partial class AddIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isDeleted",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDeleted",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Competitions");
        }
    }
}
