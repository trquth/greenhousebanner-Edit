using System;
using System.Collections.Generic;

namespace greenhousebanner.Models
{
    public partial class Role
    {
        public Role()
        {
            this.Users = new List<User>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
