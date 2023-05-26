using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class CompetitionsUser
    {
        public CompetitionsUser()
        {
            PickerQuestions = new HashSet<PickerQuestion>();
            Results = new HashSet<Result>();
        }

        public int Cuid { get; set; }
        public int ComId { get; set; }
        public string UserId { get; set; } = null!;

        public virtual Competition Com { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<PickerQuestion> PickerQuestions { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
