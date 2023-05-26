namespace WebCongDoan_API.Models
{
    public partial class PrizeType
    {
        public PrizeType()
        {
            Prizes = new HashSet<Prize>();
        }

        public int PriTid { get; set; }
        public string? PriTname { get; set; }

        public virtual ICollection<Prize> Prizes { get; set; }
    }
}
