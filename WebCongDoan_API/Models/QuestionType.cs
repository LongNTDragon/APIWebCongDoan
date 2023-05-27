namespace WebCongDoan_API.Models
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            Questions = new HashSet<Question>();
        }

        public int QuesTId { get; set; }
        public string QuesTName { get; set; } = null!;

        public virtual ICollection<Question> Questions { get; set; }
    }
}
