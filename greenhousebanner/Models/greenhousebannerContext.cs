using System.Data.Entity;
using greenhousebanner.Models.Mapping;

namespace greenhousebanner.Models
{
    public partial class GreenhouseBannerContext : DbContext
    {
        static GreenhouseBannerContext()
        {
            Database.SetInitializer<GreenhouseBannerContext>(null);
        }

        public GreenhouseBannerContext()
            : base("Name=GreenhouseBannerContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        //public DbSet<Banner> Banners { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RightBanner> RightBanners { get; set; }
        public DbSet<TitleRightBanner> TitleRightBanners { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BannerMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RightBannerMap());
            modelBuilder.Configurations.Add(new TitleRightBannerMap());
        }
    }
}
