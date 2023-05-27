using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCongDoan_API.Migrations
{
    public partial class Add_TblCompetitionExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitions_Exams",
                columns: table => new
                {
                    CEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamID = table.Column<int>(type: "int", nullable: false),
                    ComID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CompetitionsExam", x => x.CEID);
                    table.ForeignKey(
                        name: "FK_Competitions_Exams_Competitions",
                        column: x => x.ComID,
                        principalTable: "Competitions",
                        principalColumn: "ComID");
                    table.ForeignKey(
                        name: "Fk_Competitions_Exams_Exams",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "ExamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Exams_ComID",
                table: "Competitions_Exams",
                column: "ComID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Exams_ExamID",
                table: "Competitions_Exams",
                column: "ExamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competitions_Exams");
        }
    }
}
