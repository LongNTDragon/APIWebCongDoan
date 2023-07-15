namespace WebCongDoan_API.Models
{
    public class CompetitionsPrizesUsers
    {
        public int Id { get; set; }
        public int Cpid { get; set; }
        public string UserId { get; set; } = null!;

        public virtual CompetitionsPrize ComPr { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
