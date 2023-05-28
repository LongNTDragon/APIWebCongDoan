using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCongDoan_API.Migrations
{
    public partial class Delete_TblImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Images",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Images",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ImgID",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_ImgID",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ImgID",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ImgID",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Tags",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgSrc",
                table: "Tags",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Blogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgSrc",
                table: "Blogs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ImgSrc",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ImgSrc",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "ImgID",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImgID",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ImgID",
                table: "Tags",
                column: "ImgID");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ImgID",
                table: "Blogs",
                column: "ImgID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Images",
                table: "Blogs",
                column: "ImgID",
                principalTable: "Images",
                principalColumn: "ImgID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Images",
                table: "Tags",
                column: "ImgID",
                principalTable: "Images",
                principalColumn: "ImgID");
        }
    }
}
