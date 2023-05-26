using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCongDoan_API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__DB9CAA7F39F2D847", x => x.DepID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImgID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImgSrc = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Images__352F541359595AB8", x => x.ImgID);
                });

            migrationBuilder.CreateTable(
                name: "PrizeTypes",
                columns: table => new
                {
                    PriTID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriTName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PrizeTyp__0AED25F50EE96F60", x => x.PriTID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    ComID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ExamTimes = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserQuan = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    DepID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Competit__E15F4132B3D07EF2", x => x.ComID);
                    table.ForeignKey(
                        name: "FK_Competitions_Departments",
                        column: x => x.DepID,
                        principalTable: "Departments",
                        principalColumn: "DepID");
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BlogDetai = table.Column<string>(type: "text", nullable: true),
                    TagID = table.Column<int>(type: "int", nullable: true),
                    ImgID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_Blogs_Images",
                        column: x => x.ImgID,
                        principalTable: "Images",
                        principalColumn: "ImgID");
                });

            migrationBuilder.CreateTable(
                name: "Prizes",
                columns: table => new
                {
                    PriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PriTID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prizes__60886EEF679A18F8", x => x.PriID);
                    table.ForeignKey(
                        name: "FK_Prizes_PrizeTypes",
                        column: x => x.PriTID,
                        principalTable: "PrizeTypes",
                        principalColumn: "PriTID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Candidates_Roles",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                    table.ForeignKey(
                        name: "FK_Users_Departments",
                        column: x => x.DepID,
                        principalTable: "Departments",
                        principalColumn: "DepID");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuesDetail = table.Column<string>(type: "text", nullable: true),
                    AnsOfQues = table.Column<string>(type: "text", nullable: true),
                    TrueAnswer = table.Column<string>(type: "text", nullable: true),
                    ComID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Question__5F3F5F149F60A4ED", x => x.QuesID);
                    table.ForeignKey(
                        name: "FK_Questions_Competitions",
                        column: x => x.ComID,
                        principalTable: "Competitions",
                        principalColumn: "ComID");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TagDetail = table.Column<string>(type: "text", nullable: true),
                    ImgID = table.Column<int>(type: "int", nullable: false),
                    BlogID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagID);
                    table.ForeignKey(
                        name: "FK_Tags_Blogs",
                        column: x => x.BlogID,
                        principalTable: "Blogs",
                        principalColumn: "BlogID");
                    table.ForeignKey(
                        name: "FK_Tags_Images",
                        column: x => x.ImgID,
                        principalTable: "Images",
                        principalColumn: "ImgID");
                });

            migrationBuilder.CreateTable(
                name: "Competitions_Prizes",
                columns: table => new
                {
                    CPID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriID = table.Column<int>(type: "int", nullable: false),
                    ComID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Competit__F5B22BE6023BABED", x => x.CPID);
                    table.ForeignKey(
                        name: "FK_Competitions_Prizes_Competitions",
                        column: x => x.ComID,
                        principalTable: "Competitions",
                        principalColumn: "ComID");
                    table.ForeignKey(
                        name: "Fk_Competitions_Prizes_Prizes",
                        column: x => x.PriID,
                        principalTable: "Prizes",
                        principalColumn: "PriID");
                });

            migrationBuilder.CreateTable(
                name: "Competitions_Blogs_Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComID = table.Column<int>(type: "int", nullable: false),
                    BlogID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions_Blogs_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Competitions_Blogs_Users_Blogs",
                        column: x => x.BlogID,
                        principalTable: "Blogs",
                        principalColumn: "BlogID");
                    table.ForeignKey(
                        name: "FK_Competitions_Blogs_Users_Competitions",
                        column: x => x.ComID,
                        principalTable: "Competitions",
                        principalColumn: "ComID");
                    table.ForeignKey(
                        name: "FK_Competitions_Blogs_Users_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Competitions_Users",
                columns: table => new
                {
                    CUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Competit__F46C15E9B97F0210", x => x.CUID);
                    table.ForeignKey(
                        name: "FK_Competitions_Users_Competitions",
                        column: x => x.ComID,
                        principalTable: "Competitions",
                        principalColumn: "ComID");
                    table.ForeignKey(
                        name: "FK_Competitions_Users_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Picker_Questions",
                columns: table => new
                {
                    PQID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuesID = table.Column<int>(type: "int", nullable: false),
                    CUID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Picker_Q__BD8016647D44F54A", x => x.PQID);
                    table.ForeignKey(
                        name: "FK_Picker_Questions_Competitions_Users",
                        column: x => x.CUID,
                        principalTable: "Competitions_Users",
                        principalColumn: "CUID");
                    table.ForeignKey(
                        name: "FK_Picker_Questions_Questions",
                        column: x => x.QuesID,
                        principalTable: "Questions",
                        principalColumn: "QuesID");
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUID = table.Column<int>(type: "int", nullable: false),
                    TrueAns = table.Column<int>(type: "int", nullable: true),
                    FalseAns = table.Column<int>(type: "int", nullable: true),
                    StartTimes = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndTimes = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Results__2978821658FD414D", x => x.ResID);
                    table.ForeignKey(
                        name: "FK_Results_Competitions_Users",
                        column: x => x.CUID,
                        principalTable: "Competitions_Users",
                        principalColumn: "CUID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ImgID",
                table: "Blogs",
                column: "ImgID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_DepID",
                table: "Competitions",
                column: "DepID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Blogs_Users_BlogID",
                table: "Competitions_Blogs_Users",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Blogs_Users_ComID",
                table: "Competitions_Blogs_Users",
                column: "ComID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Blogs_Users_UserID",
                table: "Competitions_Blogs_Users",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Prizes_ComID",
                table: "Competitions_Prizes",
                column: "ComID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Prizes_PriID",
                table: "Competitions_Prizes",
                column: "PriID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Users_ComID",
                table: "Competitions_Users",
                column: "ComID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Users_UserID",
                table: "Competitions_Users",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Picker_Questions_CUID",
                table: "Picker_Questions",
                column: "CUID");

            migrationBuilder.CreateIndex(
                name: "IX_Picker_Questions_QuesID",
                table: "Picker_Questions",
                column: "QuesID");

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_PriTID",
                table: "Prizes",
                column: "PriTID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ComID",
                table: "Questions",
                column: "ComID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_CUID",
                table: "Results",
                column: "CUID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogID",
                table: "Tags",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ImgID",
                table: "Tags",
                column: "ImgID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepID",
                table: "Users",
                column: "DepID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competitions_Blogs_Users");

            migrationBuilder.DropTable(
                name: "Competitions_Prizes");

            migrationBuilder.DropTable(
                name: "Picker_Questions");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Prizes");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Competitions_Users");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "PrizeTypes");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
