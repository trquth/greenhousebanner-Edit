using greenhousebanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenhousebanner.Service
{
    interface IServiceRightBanner
    {
        bool SaveAdd(RightBanner item);
        IEnumerable<RightBanner> GetAllRightBanner();
        IEnumerable<RightBanner> GetAllRightBannerActive();
        RightBanner GetItemTitle(int id);
        bool SaveEdit(RightBanner item);
        bool Delete(int id);
        bool IsActive(int id);
        bool UpdateSTT(RightBanner item);
    }
}
