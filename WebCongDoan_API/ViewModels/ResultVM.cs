namespace WebCongDoan_API.ViewModels
{
    public class ResultVM
    {
        public int ResId { get; set; }
        public int Cuid { get; set; }
        public int? TrueAns { get; set; }
        public int? FalseAns { get; set; }
        public DateTime? StartTimes { get; set; }
        public DateTime? EndTimes { get; set; }
    }
}
