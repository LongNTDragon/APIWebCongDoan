using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebCongDoan_API.Models
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Competition> Competitions { get; set; } = null!;
        public virtual DbSet<CompetitionsBlogsUser> CompetitionsBlogsUsers { get; set; } = null!;
        public virtual DbSet<CompetitionsUser> CompetitionsUsers { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<PickerQuestion> PickerQuestions { get; set; } = null!;
        public virtual DbSet<QuestionType> QuestionTypes { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Prize> Prizes { get; set; } = null!;
        public virtual DbSet<PrizeType> PrizeTypes { get; set; } = null!;
        public virtual DbSet<CompetitionsPrize> CompetitionsPrizes { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<CompetitionsExam> CompetitionsExams { get; set; } = null!;
        public virtual DbSet<CompetitionsPrizesUsers> CompetitionsPrizesUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CuocThiCongDoan;User ID=sa;Password=123;");
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CuocThiCongDoan;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.BlogDetai).HasColumnType("text");

                entity.Property(e => e.BlogName).HasMaxLength(255);

                entity.Property(e => e.ImgName).HasColumnType("text");

                entity.Property(e => e.ImgSrc).HasColumnType("text");
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.HasKey(e => e.ComId)
                    .HasName("PK__Competit__E15F4132B3D07EF2");

                entity.Property(e => e.ComId).HasColumnName("ComID");

                entity.Property(e => e.ComName).HasMaxLength(255);

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserQuan).HasDefaultValueSql("((0))");

                entity.Property(e => e.isDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Departments");
            });

            modelBuilder.Entity<CompetitionsBlogsUser>(entity =>
            {
                entity.ToTable("Competitions_Blogs_Users");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.ComId).HasColumnName("ComID");

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.CompetitionsBlogsUsers)
                    .HasForeignKey(d => d.BlogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Blogs_Users_Blogs");

                entity.HasOne(d => d.Com)
                    .WithMany(p => p.CompetitionsBlogsUsers)
                    .HasForeignKey(d => d.ComId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Blogs_Users_Competitions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompetitionsBlogsUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Blogs_Users_Users");
            });

            modelBuilder.Entity<CompetitionsUser>(entity =>
            {
                entity.HasKey(e => e.Cuid)
                    .HasName("PK__Competit__F46C15E9B97F0210");

                entity.ToTable("Competitions_Users");

                entity.Property(e => e.Cuid).HasColumnName("CUID");

                entity.Property(e => e.ComId).HasColumnName("ComID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Com)
                    .WithMany(p => p.CompetitionsUsers)
                    .HasForeignKey(d => d.ComId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Users_Competitions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompetitionsUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Users_Users");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__Departme__DB9CAA7F39F2D847");

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.DepName).HasMaxLength(255);
            });

            modelBuilder.Entity<PickerQuestion>(entity =>
            {
                entity.HasKey(e => e.Pqid)
                    .HasName("PK__Picker_Q__BD8016647D44F54A");

                entity.ToTable("Picker_Questions");

                entity.Property(e => e.Pqid).HasColumnName("PQID");

                entity.Property(e => e.Cuid).HasColumnName("CUID");

                entity.Property(e => e.QuesId).HasColumnName("QuesID");

                entity.Property(e => e.Answer).HasColumnType("text");

                entity.HasOne(d => d.Cu)
                    .WithMany(p => p.PickerQuestions)
                    .HasForeignKey(d => d.Cuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Picker_Questions_Competitions_Users");

                entity.HasOne(d => d.Ques)
                    .WithMany(p => p.PickerQuestions)
                    .HasForeignKey(d => d.QuesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Picker_Questions_Questions");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.ExamName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.HasKey(e => e.QuesTId)
                    .HasName("PK__QuestionType");

                entity.Property(e => e.QuesTId).HasColumnName("QuesTID");

                entity.Property(e => e.QuesTName).HasMaxLength(255);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuesId)
                    .HasName("PK__Question__5F3F5F149F60A4ED");

                entity.Property(e => e.QuesId).HasColumnName("QuesID");

                entity.Property(e => e.AnsOfQues).HasColumnType("text");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.QuesTId).HasColumnName("QuesTID");

                entity.Property(e => e.QuesDetail).HasColumnType("text");

                entity.Property(e => e.TrueAnswer).HasColumnType("text");

                entity.HasOne(d => d.Exa)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_Exams");

                entity.HasOne(d => d.QuesT)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuesTId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_QuestionTypes");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.ResId)
                    .HasName("PK__Results__2978821658FD414D");

                entity.Property(e => e.ResId).HasColumnName("ResID");

                entity.Property(e => e.Cuid).HasColumnName("CUID");

                entity.Property(e => e.EndTimes).HasColumnType("datetime");

                entity.Property(e => e.StartTimes).HasColumnType("datetime");

                entity.HasOne(d => d.Cu)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.Cuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Results_Competitions_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.ImgName).HasColumnType("text");

                entity.Property(e => e.ImgSrc).HasColumnType("text");

                entity.Property(e => e.TagDetail).HasColumnType("text");

                entity.Property(e => e.TagName).HasMaxLength(255);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.BlogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tags_Blogs");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserAddress).HasMaxLength(255);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.isDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Password)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Departments");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidates_Roles");
            });

            modelBuilder.Entity<CompetitionsPrize>(entity =>
            {
                entity.HasKey(e => e.Cpid)
                    .HasName("PK__Competit__F5B22BE6023BABED");

                entity.ToTable("Competitions_Prizes");

                entity.Property(e => e.Cpid).HasColumnName("CPID");

                entity.Property(e => e.ComId).HasColumnName("ComID");

                entity.Property(e => e.PriId).HasColumnName("PriID");

                entity.Property(e => e.PriTid).HasColumnName("PriTID");

                entity.Property(e => e.Quantity).HasColumnName("Quantity");

                entity.Property(e => e.PrizeDetail).HasMaxLength(255);

                entity.HasOne(d => d.Com)
                    .WithMany(p => p.CompetitionsPrizes)
                    .HasForeignKey(d => d.ComId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Prizes_Competitions");

                entity.HasOne(d => d.Pri)
                    .WithMany(p => p.CompetitionsPrizes)
                    .HasForeignKey(d => d.PriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Competitions_Prizes_Prizes");

                entity.HasOne(d => d.PriT)
                    .WithMany(p => p.CompetitionsPrizes)
                    .HasForeignKey(d => d.PriTid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Prizes_PrizeTypes");
            });

            modelBuilder.Entity<CompetitionsPrizesUsers>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__CompetitionsPrizesUsers");

                entity.ToTable("Competitions_Prizes_Users");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cpid).HasColumnName("CPID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.ComPr)
                    .WithMany(p => p.CompetitionsPrizesUsers)
                    .HasForeignKey(d => d.Cpid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Prizes_Users_ComPr");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompetitionsPrizesUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Prizes_Users_Users");
            });

            modelBuilder.Entity<CompetitionsExam>(entity =>
            {
                entity.HasKey(e => e.Ceid)
                    .HasName("PK__CompetitionsExam");

                entity.ToTable("Competitions_Exams");

                entity.Property(e => e.Ceid).HasColumnName("CEID");

                entity.Property(e => e.ComId).HasColumnName("ComID");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.HasOne(d => d.Com)
                    .WithMany(p => p.CompetitionsExams)
                    .HasForeignKey(d => d.ComId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Exams_Competitions");

                entity.HasOne(d => d.Exa)
                    .WithMany(p => p.CompetitionsExams)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Competitions_Exams_Exams");
            });

            modelBuilder.Entity<Prize>(entity =>
            {
                entity.HasKey(e => e.PriId)
                    .HasName("PK__Prizes__60886EEF679A18F8");

                entity.Property(e => e.PriId).HasColumnName("PriID");

                entity.Property(e => e.PriName).HasMaxLength(255);
            });

            modelBuilder.Entity<PrizeType>(entity =>
            {
                entity.HasKey(e => e.PriTid)
                    .HasName("PK__PrizeTyp__0AED25F50EE96F60");

                entity.Property(e => e.PriTid).HasColumnName("PriTID");

                entity.Property(e => e.PriTname)
                    .HasMaxLength(255)
                    .HasColumnName("PriTName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
