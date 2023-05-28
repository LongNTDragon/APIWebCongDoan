namespace WebCongDoan_API.ViewModels
{
    public class TagVM
    {
        public int TagId { get; set; }
        public string? TagName { get; set; }
        public string? TagDetail { get; set; }
        public string ImgName { get; set; } = null!;
        public string ImgSrc { get; set; } = null!;
        public int BlogId { get; set; }
    }
}
