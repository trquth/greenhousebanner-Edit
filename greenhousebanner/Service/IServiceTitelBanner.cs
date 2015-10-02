using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using greenhousebanner.Models;

namespace greenhousebanner.Service
{
    interface IServiceTitelBanner
    {
        bool SaveAdd(TitleRightBanner item);
        IEnumerable<TitleRightBanner> GetAllTitleBanner();
        IEnumerable<TitleRightBanner> GetAllTitleBannerActive();
        TitleRightBanner GetItemTitle(int id);
        bool SaveEdit(TitleRightBanner item);
        bool Delete(int id);
        bool IsActive(int id);
    }
}
