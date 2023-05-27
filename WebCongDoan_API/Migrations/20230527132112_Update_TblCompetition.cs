using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCongDoan_API.Migrations
{
    public partial class Update_TblCompetition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitionComId",
                table: "Questions",
                type: "int",
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
    }
}
