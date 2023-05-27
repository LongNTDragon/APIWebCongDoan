using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCongDoan_API.Migrations
{
    public partial class Update_TblPickerQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Competitions",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ComID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ComID",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "CompetitionComId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Picker_Questions",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CompetitionComId",
                table: "Questions",
                column: "CompetitionComId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Competitions_CompetitionComId",
                table: "Questions",
                column: "CompetitionComId",
                principalTable: "Competitions",
                principalColumn: "ComID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Competitions_CompetitionComId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CompetitionComId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CompetitionComId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Picker_Questions");

            migrationBuilder.AddColumn<int>(
                name: "ComID",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ComID",
                table: "Questions",
                column: "ComID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Competitions",
                table: "Questions",
                column: "ComID",
                principalTable: "Competitions",
                principalColumn: "ComID");
        }
    }
}
