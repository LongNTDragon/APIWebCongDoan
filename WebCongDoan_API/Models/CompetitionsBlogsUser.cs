using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class CompetitionsBlogsUser
    {
        public int Id { get; set; }
        public int ComId { get; set; }
        public int BlogId { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime? PostDate { get; set; }

        public virtual Blog Blog { get; set; } = null!;
        public virtual Competition Com { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
