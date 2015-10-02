using System;
using System.Collections.Generic;

namespace greenhousebanner.Models
{
    public partial class RightBanner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlanName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<System.Guid> UserModifyId { get; set; }
        public string Unit { get; set; }
        public string Link { get; set; }
        public Nullable<int> STT { get; set; }
    }
}
