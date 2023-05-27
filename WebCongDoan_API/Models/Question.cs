using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class Question
    {
        public Question()
        {
            PickerQuestions = new HashSet<PickerQuestion>();
        }

        public int QuesId { get; set; }
        public string? QuesDetail { get; set; }
        public string? AnsOfQues { get; set; }
        public string? TrueAnswer { get; set; }
        public int ComId { get; set; }
        public int ExamId { get; set; }

        public virtual Competition Com { get; set; } = null!;
        public virtual Exam Exa { get; set; } = null!;
        public virtual ICollection<PickerQuestion> PickerQuestions { get; set; }
    }
}
