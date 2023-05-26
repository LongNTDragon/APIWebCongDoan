using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class Tag
    {
        public int TagId { get; set; }
        public string? TagName { get; set; }
        public string? TagDetail { get; set; }
        public int ImgId { get; set; }
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; } = null!;
        public virtual Image Img { get; set; } = null!;
    }
}
