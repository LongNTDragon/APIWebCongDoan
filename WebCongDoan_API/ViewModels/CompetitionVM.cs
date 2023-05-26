namespace WebCongDoan_API.ViewModels
{
    public class CompetitionVM
    {
        public int ComId { get; set; }
        public string ComName { get; set; } = null!;
        public int ExamTimes { get; set;}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? UserQuan { get; set; }
        public int DepId { get; set; }
    }
}
