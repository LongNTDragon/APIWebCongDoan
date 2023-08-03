namespace WebCongDoan_API.ViewModels
{
    public class RegisterVM
    {
        public string UserName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int DepId { get; set; }
        public int RoleId { get; set; }
    }
}
