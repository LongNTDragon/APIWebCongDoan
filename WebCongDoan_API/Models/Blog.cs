using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class Blog
    {
        public Blog()
        {
            CompetitionsBlogsUsers = new HashSet<CompetitionsBlogsUser>();
            Tags = new HashSet<Tag>();
        }

        public int BlogId { get; set; }
        public string? BlogName { get; set; }
        public string? BlogDetai { get; set; }
        public string ImgName { get; set; } = null!;
        public string ImgSrc { get; set; } = null!;

        public virtual ICollection<CompetitionsBlogsUser> CompetitionsBlogsUsers { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
