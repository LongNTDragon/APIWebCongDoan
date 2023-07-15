using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class User
    {
        public User()
        {
            CompetitionsBlogsUsers = new HashSet<CompetitionsBlogsUser>();
            CompetitionsUsers = new HashSet<CompetitionsUser>();
            CompetitionsPrizesUsers = new HashSet<CompetitionsPrizesUsers>();
        }

        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? UserAddress { get; set; }
        public int RoleId { get; set; }
        public int DepId { get; set; }
        public int? isDeleted { get; set; }

        public virtual Department Dep { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<CompetitionsBlogsUser> CompetitionsBlogsUsers { get; set; }
        public virtual ICollection<CompetitionsUser> CompetitionsUsers { get; set; }
        public virtual ICollection<CompetitionsPrizesUsers> CompetitionsPrizesUsers { get; set; }
    }
}
