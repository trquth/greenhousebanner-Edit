using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using greenhousebanner.Service;

namespace greenhousebanner.Controllers
{
    public class ContentController : Controller
    {
        private readonly IServiceRightBanner _iServiceRightBanner;
        private readonly IServiceTitelBanner _iServiceTitelBanner;

        public ContentController()
        {
            this._iServiceRightBanner = new ServiceRightBanner();
            this._iServiceTitelBanner = new ServiceTitelBanner();
        }
        [OutputCache(Duration = 30, VaryByParam = "none")]
        public ActionResult Index()
        {
            var model = _iServiceRightBanner.GetAllRightBannerActive();
            return View(model);
        }
        //[OutputCache(Duration = 30, VaryByParam = "none")]
        public ActionResult GetTitelBanner()
        {
            var model = _iServiceTitelBanner.GetAllTitleBannerActive();
            return PartialView("_TitleBanner", model);
        }
    }
}