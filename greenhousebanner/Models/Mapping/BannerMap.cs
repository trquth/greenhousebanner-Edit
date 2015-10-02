using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace greenhousebanner.Models.Mapping
{
    public class BannerMap : EntityTypeConfiguration<Banner>
    {
        public BannerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.BannerName)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.BannerImage)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Link)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("Banner");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BannerName).HasColumnName("BannerName");
            this.Property(t => t.BannerImage).HasColumnName("BannerImage");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.Position).HasColumnName("Position");
            this.Property(t => t.DateTimeCreate).HasColumnName("DateTimeCreate");
            this.Property(t => t.DateTimeModify).HasColumnName("DateTimeModify");
            this.Property(t => t.GuidCreate).HasColumnName("GuidCreate");
            this.Property(t => t.GuidModify).HasColumnName("GuidModify");
            this.Property(t => t.BannerDescription).HasColumnName("BannerDescription");
            this.Property(t => t.TypeBanner).HasColumnName("TypeBanner");
            this.Property(t => t.Link).HasColumnName("Link");
        }
    }
}
