using System;
using System.Collections.Generic;

namespace greenhousebanner.Models
{
    public partial class TitleRightBanner
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<System.Guid> UserModifyId { get; set; }
    }
}
