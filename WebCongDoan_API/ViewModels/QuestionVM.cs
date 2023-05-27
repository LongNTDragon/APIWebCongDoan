namespace WebCongDoan_API.ViewModels
{
    public class QuestionVM
    {
        public int QuesId { get; set; }
        public string? QuesDetail { get; set; }
        public string? AnsOfQues { get; set; }
        public string? TrueAnswer { get; set; }
        public int ExamId { get; set; }
        public int QuesTId { get; set; }
    }
}
