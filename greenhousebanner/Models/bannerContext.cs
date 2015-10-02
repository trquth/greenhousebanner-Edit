using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using greenhousebanner.Models.Mapping;

namespace greenhousebanner.Models
{
    public partial class bannerContext : DbContext
    {
        static bannerContext()
        {
            Database.SetInitializer<bannerContext>(null);
        }

        public bannerContext()
            : base("Name=bannerContext")
        {
        }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<RightBanner> RightBanners { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TitleRightBanner> TitleRightBanners { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BannerMap());
            modelBuilder.Configurations.Add(new RightBannerMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TitleRightBannerMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
