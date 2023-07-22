namespace WebCongDoan_API.ViewModels
{
    public class UserVM
    {
        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? UserAddress { get; set; }
        public int RoleId { get; set; }
        public int DepId { get; set; }
        public int? isDeleted { get; set; }
    }
}
