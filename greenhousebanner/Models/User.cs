using System;
using System.Collections.Generic;

namespace greenhousebanner.Models
{
    public partial class User
    {
        public System.Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int IdRole { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.Guid> UserCreateId { get; set; }
        public bool IsDelete { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<System.Guid> UserModifyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual Role Role { get; set; }
    }
}
