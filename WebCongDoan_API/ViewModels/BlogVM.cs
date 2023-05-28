namespace WebCongDoan_API.ViewModels
{
    public class BlogVM
    {
        public int BlogId { get; set; }
        public string? BlogName { get; set; }
        public string? BlogDetai { get; set; }
        public string ImgName { get; set; } = null!;
        public string ImgSrc { get; set; } = null!;
    }
}