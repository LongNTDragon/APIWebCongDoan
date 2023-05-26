using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class Image
    {
        public Image()
        {
            Blogs = new HashSet<Blog>();
            Tags = new HashSet<Tag>();
        }

        public int ImgId { get; set; }
        public string ImgName { get; set; } = null!;
        public string ImgSrc { get; set; } = null!;

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
