namespace WebCongDoan_API.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Questions = new HashSet<Question>();
            CompetitionsExams = new HashSet<CompetitionsExam>();
        }

        public int ExamId { get; set; }
        public string ExamName { get; set; } = null!;

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<CompetitionsExam> CompetitionsExams { get; set; }
    }
}
