﻿namespace WebCongDoan_API.ViewModels
{
    public class RegisterVM
    {
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int DepId { get; set; }
    }
}
