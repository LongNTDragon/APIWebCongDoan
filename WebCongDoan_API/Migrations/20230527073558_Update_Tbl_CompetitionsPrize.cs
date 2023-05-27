using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCongDoan_API.Migrations
{
    public partial class Update_Tbl_CompetitionsPrize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_PrizeTypes",
                table: "Prizes");

            migrationBuilder.DropIndex(
                name: "IX_Prizes_PriTID",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "PriTID",
                table: "Prizes");

            migrationBuilder.AddColumn<int>(
                name: "PriTID",
                table: "Competitions_Prizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Prizes_PriTID",
                table: "Competitions_Prizes",
                column: "PriTID");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Prizes_PrizeTypes",
                table: "Competitions_Prizes",
                column: "PriTID",
                principalTable: "PrizeTypes",
                principalColumn: "PriTID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Prizes_PrizeTypes",
                table: "Competitions_Prizes");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_Prizes_PriTID",
                table: "Competitions_Prizes");

            migrationBuilder.DropColumn(
                name: "PriTID",
                table: "Competitions_Prizes");

            migrationBuilder.AddColumn<int>(
                name: "PriTID",
                table: "Prizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_PriTID",
                table: "Prizes",
                column: "PriTID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_PrizeTypes",
                table: "Prizes",
                column: "PriTID",
                principalTable: "PrizeTypes",
                principalColumn: "PriTID");
        }
    }
}
