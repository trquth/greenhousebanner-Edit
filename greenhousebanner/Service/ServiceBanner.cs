using System.Collections.Generic;
using greenhousebanner.Models;
using greenhousebanner.Repository;

namespace greenhousebanner.Service
{
    public class ServiceBanner : IServiceBanner
    {
        private readonly BannerRepository _manager = new BannerRepository();

        public Banner GetItemBanner(int id)
        {
            return _manager.FindById(id);
        }

        public bool SaveEdit(Banner item)
        {
            return _manager.Update(item);
        }
        public bool Disable(int id)
        {
            return _manager.DisableById(id);
        }
        public bool SaveAdd(Banner item)
        {
            return _manager.Add(item);
        }

        public IEnumerable<Banner> GetAllBanner()
        {
            return _manager.GetAllBanner();
        }

        public IEnumerable<Banner> GetAllBannerActive()
        {
            return _manager.GetAllActiveBanner();
        }



        public IEnumerable<Banner> GetAllBannerByType(int type)
        {
            return _manager.GetAllActiveBannerByType(type);
        }
    }
}