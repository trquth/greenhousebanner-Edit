using System;
using System.Collections.Generic;

namespace greenhousebanner.Models
{
    public partial class Banner
    {
        public int Id { get; set; }
        public string BannerName { get; set; }
        public string BannerImage { get; set; }
        public bool IsActive { get; set; }
        public int Position { get; set; }
        public System.DateTime DateTimeCreate { get; set; }
        public Nullable<System.DateTime> DateTimeModify { get; set; }
        public System.Guid GuidCreate { get; set; }
        public Nullable<System.Guid> GuidModify { get; set; }
        public string BannerDescription { get; set; }
        public Nullable<int> TypeBanner { get; set; }
        public string Link { get; set; }
    }
}
