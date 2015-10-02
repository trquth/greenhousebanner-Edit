using System.Collections.Generic;
using greenhousebanner.Models;

namespace greenhousebanner.Service
{
    interface IServiceBanner
    {
        bool Disable(int id);
        IEnumerable<Banner> GetAllBanner();
        IEnumerable<Banner> GetAllBannerActive();
        IEnumerable<Banner> GetAllBannerByType(int type);
        Banner GetItemBanner(int id);
        bool SaveAdd(Banner item);
        bool SaveEdit(Banner item);
    }
}
