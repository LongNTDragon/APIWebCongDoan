namespace WebCongDoan_API.Models
{
    public partial class CompetitionsExam
    {
        public int Ceid { get; set; }
        public int ExamId { get; set; }
        public int ComId { get; set; }

        public virtual Competition Com { get; set; } = null!;
        public virtual Exam Exa { get; set; } = null!;
    }
}
