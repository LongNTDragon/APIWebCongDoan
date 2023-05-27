using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class Competition
    {
        public Competition()
        {
            CompetitionsBlogsUsers = new HashSet<CompetitionsBlogsUser>();
            CompetitionsUsers = new HashSet<CompetitionsUser>();
            CompetitionsPrizes = new HashSet<CompetitionsPrize>();
            CompetitionsExams = new HashSet<CompetitionsExam>();
        }

        public int ComId { get; set; }
        public string ComName { get; set; } = null!;
        public int ExamTimes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? UserQuan { get; set; }
        public int DepId { get; set; }

        public virtual Department Dep { get; set; } = null!;
        public virtual ICollection<CompetitionsBlogsUser> CompetitionsBlogsUsers { get; set; }
        public virtual ICollection<CompetitionsUser> CompetitionsUsers { get; set; }
        public virtual ICollection<CompetitionsPrize> CompetitionsPrizes { get; set; }
        public virtual ICollection<CompetitionsExam> CompetitionsExams { get; set; }
    }
}
