using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace greenhousebanner.Models.Mapping
{
    public class TitleRightBannerMap : EntityTypeConfiguration<TitleRightBanner>
    {
        public TitleRightBannerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("TitleRightBanner");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ModifyDate).HasColumnName("ModifyDate");
            this.Property(t => t.UserModifyId).HasColumnName("UserModifyId");
        }
    }
}
