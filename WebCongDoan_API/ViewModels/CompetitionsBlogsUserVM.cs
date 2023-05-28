namespace WebCongDoan_API.ViewModels
{
    public class CompetitionsBlogsUserVM
    {
        public int Id { get; set; }
        public int ComId { get; set; }
        public int BlogId { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime? PostDate { get; set; }
    }
}
