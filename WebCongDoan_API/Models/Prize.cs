namespace WebCongDoan_API.Models
{
    public partial class Prize
    {
        public Prize()
        {
            CompetitionsPrizes = new HashSet<CompetitionsPrize>();
        }

        public int PriId { get; set; }
        public string? PriName { get; set; }
        
        public virtual ICollection<CompetitionsPrize> CompetitionsPrizes { get; set; }
    }
}
