using System;
using System.Collections.Generic;

namespace WebCongDoan_API.Models
{
    public partial class Department
    {
        public Department()
        {
            Competitions = new HashSet<Competition>();
            Users = new HashSet<User>();
        }

        public int DepId { get; set; }
        public string? DepName { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
