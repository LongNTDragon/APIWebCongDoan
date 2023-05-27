using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class PickerQuestion
    {
        public int Pqid { get; set; }
        public int QuesId { get; set; }
        public int Cuid { get; set; }
        public string? Answer { get; set; }
        public virtual CompetitionsUser Cu { get; set; } = null!;
        public virtual Question Ques { get; set; } = null!;
    }
}
