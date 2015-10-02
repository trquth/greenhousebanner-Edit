using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace greenhousebanner.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(350);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(350);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(350);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.IdRole).HasColumnName("IdRole");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
            this.Property(t => t.ModifyDate).HasColumnName("ModifyDate");
            this.Property(t => t.UserModifyId).HasColumnName("UserModifyId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Email).HasColumnName("Email");

            // Relationships
            this.HasRequired(t => t.Role)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.IdRole);

        }
    }
}
