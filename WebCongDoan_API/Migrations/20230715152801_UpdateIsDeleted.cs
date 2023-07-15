using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCongDoan_API.Migrations
{
    public partial class UpdateIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "isDeleted",
                table: "Users",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "isDeleted",
                table: "Competitions",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "isDeleted",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<int>(
                name: "isDeleted",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((0))");
        }
    }
}
