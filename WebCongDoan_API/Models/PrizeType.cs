namespace WebCongDoan_API.Models
{
    public partial class PrizeType
    {
        public PrizeType()
        {
            CompetitionsPrizes = new HashSet<CompetitionsPrize>();
        }

        public int PriTid { get; set; }
        public string? PriTname { get; set; }

        public virtual ICollection<CompetitionsPrize> CompetitionsPrizes { get; set; }
    }
}
