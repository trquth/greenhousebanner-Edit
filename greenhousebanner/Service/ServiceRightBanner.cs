using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using greenhousebanner.Repository;

namespace greenhousebanner.Service
{
    public class ServiceRightBanner:IServiceRightBanner
    {
        private readonly RightBannerRepository _bannerRight = new RightBannerRepository();
        public bool SaveAdd(Models.RightBanner item)
        {
            return _bannerRight.Add(item);
        }

        public IEnumerable<Models.RightBanner> GetAllRightBanner()
        {
            return _bannerRight.GetAllRightBanner();
        }

        public Models.RightBanner GetItemTitle(int id)
        {
            return _bannerRight.FindRightBannerById(id);
        }

        public bool SaveEdit(Models.RightBanner item)
        {
            return _bannerRight.Update(item);
        }

        public bool Delete(int id)
        {
            return _bannerRight.Delete(id);
        }

        public bool IsActive(int id)
        {
            return _bannerRight.IsActive(id);
        }


        public IEnumerable<Models.RightBanner> GetAllRightBannerActive()
        {
            return _bannerRight.GetAllRightBannerActive();
        }


        public bool UpdateSTT(Models.RightBanner item)
        {
            return _bannerRight.UpdateSTT(item);
        }
    }
}