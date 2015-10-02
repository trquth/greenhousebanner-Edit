using System;
using System.Collections.Generic;
using greenhousebanner.Models;

namespace greenhousebanner.Repository
{
    public interface IBannerRepository
    {
        Banner FindById(int id);
        bool Update(Banner item);
        IEnumerable<Banner> GetAllBanner();
        IEnumerable<Banner> GetAllActiveBanner();
        IEnumerable<Banner> GetAllActiveBannerByType(int type);
        bool DisableById(int id);
        bool Add(Banner item);
    }
}
