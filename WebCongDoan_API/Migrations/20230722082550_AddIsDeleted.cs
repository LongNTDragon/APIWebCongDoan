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
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "isDeleted",
                table: "Competitions",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.CreateTable(
                name: "Competitions_Prizes_Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CompetitionsPrizesUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Competitions_Prizes_Users_ComPr",
                        column: x => x.CPID,
                        principalTable: "Competitions_Prizes",
                        principalColumn: "CPID");
                    table.ForeignKey(
                        name: "FK_Competitions_Prizes_Users_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Prizes_Users_CPID",
                table: "Competitions_Prizes_Users",
                column: "CPID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Prizes_Users_UserID",
                table: "Competitions_Prizes_Users",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competitions_Prizes_Users");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Competitions");
        }
    }
}
