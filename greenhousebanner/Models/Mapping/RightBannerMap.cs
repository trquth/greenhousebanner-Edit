using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace greenhousebanner.Models.Mapping
{
    public class RightBannerMap : EntityTypeConfiguration<RightBanner>
    {
        public RightBannerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.PlanName)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.Unit)
                .HasMaxLength(300);

            this.Property(t => t.Link)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("RightBanner");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PlanName).HasColumnName("PlanName");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ModifyDate).HasColumnName("ModifyDate");
            this.Property(t => t.UserModifyId).HasColumnName("UserModifyId");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.Link).HasColumnName("Link");
            this.Property(t => t.STT).HasColumnName("STT");
        }
    }
}
