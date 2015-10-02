using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using greenhousebanner.Models;

namespace greenhousebanner.Repository
{
    interface IRightBannerRepository
    {
        bool Add(RightBanner item);
        IEnumerable<RightBanner> GetAllRightBanner();
        IEnumerable<RightBanner> GetAllRightBannerActive();
        RightBanner FindRightBannerById(int id);
        bool Update(RightBanner item);
        bool Delete(int id);
        bool IsActive(int id);
        bool UpdateSTT(RightBanner item);
    }
}
