using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using greenhousebanner.Models;

namespace greenhousebanner.Repository
{
    interface ITitleBannerRepository
    {
        bool Add(TitleRightBanner item);
        IEnumerable<TitleRightBanner> GetAllTitleBanner();
        IEnumerable<TitleRightBanner> GetAllTitleBannerActive();
        TitleRightBanner FindTitleById(int id);
        bool Update(TitleRightBanner item);
        bool Delete(int id);
        bool IsActive(int id);
    }
}
