namespace WebCongDoan_API.Models
{
    public partial class CompetitionsPrize
    {
        public int Cpid { get; set; }
        public int PriId { get; set; }
        public int ComId { get; set; }
        public int Quantity { get; set; }
        public string? PrizeDetail { get; set; }

        public virtual Competition Com { get; set; } = null!;
        public virtual Prize Pri { get; set; } = null!;
    }
}
