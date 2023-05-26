﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCongDoan_API.Models;

#nullable disable

namespace WebCongDoan_API.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20230526052333_Update_TblCompetitionsPrize")]
    partial class Update_TblCompetitionsPrize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebCongDoan_API.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BlogID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogId"), 1L, 1);

                    b.Property<string>("BlogDetai")
                        .HasColumnType("text");

                    b.Property<string>("BlogName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ImgId")
                        .HasColumnType("int")
                        .HasColumnName("ImgID");

                    b.Property<int?>("TagId")
                        .HasColumnType("int")
                        .HasColumnName("TagID");

                    b.HasKey("BlogId");

                    b.HasIndex("ImgId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Competition", b =>
                {
                    b.Property<int>("ComId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ComID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComId"), 1L, 1);

                    b.Property<string>("ComName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("DepId")
                        .HasColumnType("int")
                        .HasColumnName("DepID");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ExamTimes")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("UserQuan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("ComId")
                        .HasName("PK__Competit__E15F4132B3D07EF2");

                    b.HasIndex("DepId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.CompetitionsBlogsUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BlogId")
                        .HasColumnType("int")
                        .HasColumnName("BlogID");

                    b.Property<int>("ComId")
                        .HasColumnType("int")
                        .HasColumnName("ComID");

                    b.Property<DateTime?>("PostDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("ComId");

                    b.HasIndex("UserId");

                    b.ToTable("Competitions_Blogs_Users", (string)null);
                });

            modelBuilder.Entity("WebCongDoan_API.Models.CompetitionsPrize", b =>
                {
                    b.Property<int>("Cpid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CPID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cpid"), 1L, 1);

                    b.Property<int>("ComId")
                        .HasColumnType("int")
                        .HasColumnName("ComID");

                    b.Property<int>("PriId")
                        .HasColumnType("int")
                        .HasColumnName("PriID");

                    b.Property<string>("PrizeDetail")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.HasKey("Cpid")
                        .HasName("PK__Competit__F5B22BE6023BABED");

                    b.HasIndex("ComId");

                    b.HasIndex("PriId");

                    b.ToTable("Competitions_Prizes", (string)null);
                });

            modelBuilder.Entity("WebCongDoan_API.Models.CompetitionsUser", b =>
                {
                    b.Property<int>("Cuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CUID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cuid"), 1L, 1);

                    b.Property<int>("ComId")
                        .HasColumnType("int")
                        .HasColumnName("ComID");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("UserID");

                    b.HasKey("Cuid")
                        .HasName("PK__Competit__F46C15E9B97F0210");

                    b.HasIndex("ComId");

                    b.HasIndex("UserId");

                    b.ToTable("Competitions_Users", (string)null);
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Department", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DepID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepId"), 1L, 1);

                    b.Property<string>("DepName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("DepId")
                        .HasName("PK__Departme__DB9CAA7F39F2D847");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Image", b =>
                {
                    b.Property<int>("ImgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ImgID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImgId"), 1L, 1);

                    b.Property<string>("ImgName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ImgSrc")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("ImgId")
                        .HasName("PK__Images__352F541359595AB8");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.PickerQuestion", b =>
                {
                    b.Property<int>("Pqid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PQID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pqid"), 1L, 1);

                    b.Property<int>("Cuid")
                        .HasColumnType("int")
                        .HasColumnName("CUID");

                    b.Property<int>("QuesId")
                        .HasColumnType("int")
                        .HasColumnName("QuesID");

                    b.HasKey("Pqid")
                        .HasName("PK__Picker_Q__BD8016647D44F54A");

                    b.HasIndex("Cuid");

                    b.HasIndex("QuesId");

                    b.ToTable("Picker_Questions", (string)null);
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Prize", b =>
                {
                    b.Property<int>("PriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PriID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriId"), 1L, 1);

                    b.Property<string>("PriName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PriTid")
                        .HasColumnType("int")
                        .HasColumnName("PriTID");

                    b.HasKey("PriId")
                        .HasName("PK__Prizes__60886EEF679A18F8");

                    b.HasIndex("PriTid");

                    b.ToTable("Prizes");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.PrizeType", b =>
                {
                    b.Property<int>("PriTid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PriTID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriTid"), 1L, 1);

                    b.Property<string>("PriTname")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("PriTName");

                    b.HasKey("PriTid")
                        .HasName("PK__PrizeTyp__0AED25F50EE96F60");

                    b.ToTable("PrizeTypes");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Question", b =>
                {
                    b.Property<int>("QuesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("QuesID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuesId"), 1L, 1);

                    b.Property<string>("AnsOfQues")
                        .HasColumnType("text");

                    b.Property<int>("ComId")
                        .HasColumnType("int")
                        .HasColumnName("ComID");

                    b.Property<string>("QuesDetail")
                        .HasColumnType("text");

                    b.Property<string>("TrueAnswer")
                        .HasColumnType("text");

                    b.HasKey("QuesId")
                        .HasName("PK__Question__5F3F5F149F60A4ED");

                    b.HasIndex("ComId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Result", b =>
                {
                    b.Property<int>("ResId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ResID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResId"), 1L, 1);

                    b.Property<int>("Cuid")
                        .HasColumnType("int")
                        .HasColumnName("CUID");

                    b.Property<DateTime?>("EndTimes")
                        .HasColumnType("datetime");

                    b.Property<int?>("FalseAns")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTimes")
                        .HasColumnType("datetime");

                    b.Property<int?>("TrueAns")
                        .HasColumnType("int");

                    b.HasKey("ResId")
                        .HasName("PK__Results__2978821658FD414D");

                    b.HasIndex("Cuid");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TagID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"), 1L, 1);

                    b.Property<int>("BlogId")
                        .HasColumnType("int")
                        .HasColumnName("BlogID");

                    b.Property<int>("ImgId")
                        .HasColumnType("int")
                        .HasColumnName("ImgID");

                    b.Property<string>("TagDetail")
                        .HasColumnType("text");

                    b.Property<string>("TagName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TagId");

                    b.HasIndex("BlogId");

                    b.HasIndex("ImgId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("UserID");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<int>("DepId")
                        .HasColumnType("int")
                        .HasColumnName("DepID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("UserAddress")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId");

                    b.HasIndex("DepId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Blog", b =>
                {
                    b.HasOne("WebCongDoan_API.Models.Image", "Img")
                        .WithMany("Blogs")
                        .HasForeignKey("ImgId")
                        .IsRequired()
                        .HasConstraintName("FK_Blogs_Images");

                    b.Navigation("Img");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Competition", b =>
                {
                    b.HasOne("WebCongDoan_API.Models.Department", "Dep")
                        .WithMany("Competitions")
                        .HasForeignKey("DepId")
                        .IsRequired()
                        .HasConstraintName("FK_Competitions_Departments");

                    b.Navigation("Dep");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.CompetitionsBlogsUser", b =>
                {
                    b.HasOne("WebCongDoan_API.Models.Blog", "Blog")
                        .WithMany("CompetitionsBlogsUsers")
                        .HasForeignKey("BlogId")
                        .IsRequired()
                        .HasConstraintName("FK_Competitions_Blogs_Users_Blogs");

                    b.HasOne("WebCongDoan_API.Models.Competition", "Com")
                        .WithMany("CompetitionsBlogsUsers")
                        .HasForeignKey("ComId")
                        .IsRequired()
                        .HasConstraintName("FK_Competitions_Blogs_Users_Competitions");

                    b.HasOne("WebCongDoan_API.Models.User", "User")
                        .WithMany("CompetitionsBlogsUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Competitions_Blogs_Users_Users");

                    b.Navigation("Blog");

                    b.Navigation("Com");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.CompetitionsPrize", b =>
                {
                    b.HasOne("WebCongDoan_API.Models.Competition", "Com")
                        .WithMany("CompetitionsPrizes")
                        .HasForeignKey("ComId")
                        .IsRequired()
                        .HasConstraintName("FK_Competitions_Prizes_Competitions");

                    b.HasOne("WebCongDoan_API.Models.Prize", "Pri")
                        .WithMany("CompetitionsPrizes")
                        .HasForeignKey("PriId")
                        .IsRequired()
                        .HasConstraintName("Fk_Competitions_Prizes_Prizes");

                    b.Navigation("Com");

                    b.Navigation("Pri");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.CompetitionsUser", b =>
                {
                    b.HasOne("WebCongDoan_API.Models.Competition", "Com")
                        .WithMany("CompetitionsUsers")
                        .HasForeignKey("ComId")
                        .IsRequired()
                        .HasConstraintName("FK_Competitions_Users_Competitions");

                    b.HasOne("WebCongDoan_API.Models.User", "User")
                        .WithMany("CompetitionsUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Competitions_Users_Users");

                    b.Navigation("Com");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.PickerQuestion", b =>
                {
                    b.HasOne("WebCongDoan_API.Models.CompetitionsUser", "Cu")
                        .WithMany("PickerQuestions")
                        .HasForeignKey("Cuid")
                        .IsRequired()
                        .HasConstraintName("FK_Picker_Questions_Competitions_Users");

                    b.HasOne("WebCongDoan_API.Models.Question", "Ques")
                        .WithMany("PickerQuestions")
                        .HasForeignKey("QuesId")
                        .IsRequired()
                        .HasConstraintName("FK_Picker_Questions_Questions");

                    b.Navigation("Cu");

                    b.Navigation("Ques");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Prize", b =>
                {
                    b.HasOne("WebCongDoan_API.Models.PrizeType", "PriT")
                        .WithMany("Prizes")
                        .HasForeignKey("PriTid")
                        .IsRequired()
                        .HasConstraintName("FK_Prizes_PrizeTypes");

                    b.Navigation("PriT");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Question", b =>
                {
                    b.HasOne("WebCongDoan_API.Models.Competition", "Com")
                        .WithMany("Questions")
                        .HasForeignKey("ComId")
                        .IsRequired()
                        .HasConstraintName("FK_Questions_Competitions");

                    b.Navigation("Com");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Result", b =>
                {
                    b.HasOne("WebCongDoan_API.Models.CompetitionsUser", "Cu")
                        .WithMany("Results")
                        .HasForeignKey("Cuid")
                        .IsRequired()
                        .HasConstraintName("FK_Results_Competitions_Users");

                    b.Navigation("Cu");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Tag", b =>
                {
                    b.HasOne("WebCongDoan_API.Models.Blog", "Blog")
                        .WithMany("Tags")
                        .HasForeignKey("BlogId")
                        .IsRequired()
                        .HasConstraintName("FK_Tags_Blogs");

                    b.HasOne("WebCongDoan_API.Models.Image", "Img")
                        .WithMany("Tags")
                        .HasForeignKey("ImgId")
                        .IsRequired()
                        .HasConstraintName("FK_Tags_Images");

                    b.Navigation("Blog");

                    b.Navigation("Img");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.User", b =>
                {
                    b.HasOne("WebCongDoan_API.Models.Department", "Dep")
                        .WithMany("Users")
                        .HasForeignKey("DepId")
                        .IsRequired()
                        .HasConstraintName("FK_Users_Departments");

                    b.HasOne("WebCongDoan_API.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_Candidates_Roles");

                    b.Navigation("Dep");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Blog", b =>
                {
                    b.Navigation("CompetitionsBlogsUsers");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Competition", b =>
                {
                    b.Navigation("CompetitionsBlogsUsers");

                    b.Navigation("CompetitionsPrizes");

                    b.Navigation("CompetitionsUsers");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.CompetitionsUser", b =>
                {
                    b.Navigation("PickerQuestions");

                    b.Navigation("Results");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Department", b =>
                {
                    b.Navigation("Competitions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Image", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Prize", b =>
                {
                    b.Navigation("CompetitionsPrizes");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.PrizeType", b =>
                {
                    b.Navigation("Prizes");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Question", b =>
                {
                    b.Navigation("PickerQuestions");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebCongDoan_API.Models.User", b =>
                {
                    b.Navigation("CompetitionsBlogsUsers");

                    b.Navigation("CompetitionsUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
