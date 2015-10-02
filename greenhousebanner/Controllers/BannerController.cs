using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using greenhousebanner.Infrastructures.Helper;
using greenhousebanner.Models;
using greenhousebanner.Service;
using ssc.school.lesson.Infrastructures.Helper;
using greenhousebanner.Security;

namespace greenhousebanner.Controllers
{
    [RoutePrefix("Admin")]
    public class BannerController : Controller
    {
        private readonly IServiceBanner _iServiceBanner;
        int rowsdisplay = int.Parse(WebConfigurationManager.AppSettings["rowsdisplay"].ToString());

        public BannerController()
        {
            this._iServiceBanner = new ServiceBanner();
        }
         //[CustomAuthorize(Roles = "User")]
        [CustomAuthorize(Roles = "User,Admin")]  
        [Route("Banner/Index")]
        public ActionResult Index(int page = 1)
        {
            var model = _iServiceBanner.GetAllBannerActive().Skip((page - 1) * rowsdisplay).Take(rowsdisplay);
            ViewBag.Total = _iServiceBanner.GetAllBannerActive().Count();
            return View(model);
        }

        [CustomAuthorize(Roles = "User,Admin")]
        [Route("Banner/Create")]
        public ActionResult Create()
        {
            return View();
        }
        [CustomAuthorize(Roles = "User,Admin")]
        [Route("Banner/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Banner banner, HttpPostedFileBase BannerImage)
        {
            UploadResult resultImage = UploadFileResult.UploadImage(BannerImage);

            if (resultImage.IsSuccess == false && resultImage.Result != "")
            {
                SessionUserHelper.CreateSessionError(resultImage.Result);
                return View(banner);
            }
            banner.BannerImage = resultImage.FileName;

            if (ModelState.IsValid)
            {
                if (_iServiceBanner.SaveAdd(banner))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.AddSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.AddNonSuccess);
                }
                return RedirectToAction("Index");
            }

            return View(banner);
        }
        [CustomAuthorize(Roles = "User,Admin")]
        [Route("Banner/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View(_iServiceBanner.GetItemBanner(id));
        }
        [CustomAuthorize(Roles = "User,Admin")]
        [Route("Banner/Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Banner banner, HttpPostedFileBase BannerImage)
        {
            var banneritem = _iServiceBanner.GetItemBanner(banner.Id);

            //Check Image
            UploadResult resultImage = UploadFileResult.UploadImage(BannerImage);

            if (resultImage.IsSuccess == false && resultImage.Result != "")
            {
                SessionUserHelper.CreateSessionError(resultImage.Result);
                return View(banner);
            }
            banner.BannerImage = resultImage.FileName;

            if (resultImage.FileName == "")
            {
                banner.BannerImage = banneritem.BannerImage;
            }

            if (ModelState.IsValid)
            {
                if (_iServiceBanner.SaveEdit(banner))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.EditSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.EditNonSuccess);
                }
                return RedirectToAction("Index");
            }
            return View(banner);
        }
        [CustomAuthorize(Roles = "User,Admin")]
        [Route("Banner/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            SessionUserHelper.CreateSessionSuccess(_iServiceBanner.Disable(id)
                ? ConstantStrings.DeleteSuccess
                : ConstantStrings.DeleteNonSuccess);
            return RedirectToAction("Index");
        }
    }
}
