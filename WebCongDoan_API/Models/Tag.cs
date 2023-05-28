using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class Tag
    {
        public int TagId { get; set; }
        public string? TagName { get; set; }
        public string? TagDetail { get; set; }
        public string ImgName { get; set; } = null!;
        public string ImgSrc { get; set; } = null!;
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; } = null!;
    }
}
