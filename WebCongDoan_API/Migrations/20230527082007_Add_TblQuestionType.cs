using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCongDoan_API.Migrations
{
    public partial class Add_TblQuestionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuesTID",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    QuesTID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuesTName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QuestionType", x => x.QuesTID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuesTID",
                table: "Questions",
                column: "QuesTID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionTypes",
                table: "Questions",
                column: "QuesTID",
                principalTable: "QuestionTypes",
                principalColumn: "QuesTID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionTypes",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuesTID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuesTID",
                table: "Questions");
        }
    }
}
