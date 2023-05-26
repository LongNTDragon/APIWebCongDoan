using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class Result
    {
        public int ResId { get; set; }
        public int Cuid { get; set; }
        public int? TrueAns { get; set; }
        public int? FalseAns { get; set; }
        public DateTime? StartTimes { get; set; }
        public DateTime? EndTimes { get; set; }

        public virtual CompetitionsUser Cu { get; set; } = null!;
    }
}
