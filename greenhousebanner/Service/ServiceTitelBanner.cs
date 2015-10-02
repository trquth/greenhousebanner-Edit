using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using greenhousebanner.Models;
using greenhousebanner.Repository;

namespace greenhousebanner.Service
{
    public class ServiceTitelBanner:IServiceTitelBanner
    {
        private readonly TitleBannerRepository _titleBanner = new TitleBannerRepository();

      
        public bool SaveAdd(Models.TitleRightBanner item)
        {
            return _titleBanner.Add(item);
        }


        public IEnumerable<TitleRightBanner> GetAllTitleBanner()
        {
            return _titleBanner.GetAllTitleBanner();
        }


        public TitleRightBanner GetItemTitle(int id)
        {
            return _titleBanner.FindTitleById(id);
        }
        public bool SaveEdit(TitleRightBanner item)
        {
            return _titleBanner.Update(item);
        }

        public bool Delete(int id)
        {
            return _titleBanner.Delete(id);
        }


        public bool IsActive(int id)
        {
            return _titleBanner.IsActive(id);
        }


        public IEnumerable<TitleRightBanner> GetAllTitleBannerActive()
        {
            return _titleBanner.GetAllTitleBannerActive();
        }
    }
}