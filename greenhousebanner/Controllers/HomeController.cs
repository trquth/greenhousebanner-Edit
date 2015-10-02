using greenhousebanner.Service;
using System.Web.Mvc;
using greenhousebanner.Infrastructures.Validation;

namespace greenhousebanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceBanner _iServiceBanner;

        public HomeController()
        {
            this._iServiceBanner = new ServiceBanner();
        }
           [OutputCache(Duration = 30, VaryByParam = "none")]
        public ActionResult Index()
        {
            var model = _iServiceBanner.GetAllBannerActive();
            return View(model);
        }
        public ActionResult GetBannerTopLeft(int type)
        {
            var model = _iServiceBanner.GetAllBannerByType(type);
            return PartialView("_BannerTopLeft",model);
        }
        public  ActionResult GetBannerBottomLeft(int type)
        {
            var model = _iServiceBanner.GetAllBannerByType(type);
            return PartialView("_BannerBottomLeft", model);
        }
        public ActionResult Contact()
        {
            return View();
        }

        [CaptchaValidator]
        [HttpPost]
        public ActionResult Contact(FormCollection form, bool captchaValid)
        {
            if (!captchaValid)
            {
                ModelState.AddModelError("_FORM", "You did not type the verification word correctly. Please try again.");
                return View();
            }
            // If we got this far, something failed, redisplay form
            return View();
        }
    }
}