using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using greenhousebanner.Infrastructures.Helper;
using greenhousebanner.Models;
using greenhousebanner.Models.ViewModels;
using greenhousebanner.Security;
using greenhousebanner.Service;
using PagedList;

namespace greenhousebanner.Controllers
{
    public class RightBannerController : Controller
    {
        private readonly IServiceRightBanner _iServiceRighBanner;
        private const int pageSize = 10;
        public RightBannerController()
        {
            this._iServiceRighBanner = new ServiceRightBanner();
        }
        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult Index(int? page)
        {
            var model = _iServiceRighBanner.GetAllRightBanner();
            int pageNumber = page ?? 1;
            var listBanner = model.OrderByDescending(x => x.CreateDate).ThenByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            return View(listBanner);
        }
        #region Create
        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult Create(RightBannerViewModel item)
        {
            if (ModelState.IsValid)
            {
                RightBanner model = new RightBanner();
                model.Name = item.Name;
                model.PlanName = item.PlanName;
                model.Unit = item.Unit;
                model.Link = item.Link;
                if (_iServiceRighBanner.SaveAdd(model))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.AddSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.AddNonSuccess);
                }
                return RedirectToAction("Index");
            }
            return View(item);
        }
        #endregion
        #region Edit
        public RightBannerViewModel GetRightBannerViewModel(int id)
        {
            var model = _iServiceRighBanner.GetItemTitle(id);
            var item = new RightBannerViewModel();
            item.Id = model.Id;
            item.Unit = model.Unit;
            item.Name = model.Name;
            item.PlanName = model.PlanName;
            item.Link = model.Link;
            return item;
        }
        public RightBanner GetRightBannerModel(RightBannerViewModel model)
        {
            var item = new RightBanner();
            item.Id = model.Id;
            item.Name = model.Name;
            item.Unit = model.Unit;
            item.PlanName = model.PlanName;
            item.Link = model.Link;
            return item;
        }
        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult Edit(int id)
        {
            return View(GetRightBannerViewModel(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult Edit(RightBannerViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_iServiceRighBanner.SaveEdit(GetRightBannerModel(model)))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.EditSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.EditNonSuccess);
                }
                return RedirectToAction("Index");

            }
            return View(model);
        }
        #endregion
        #region Delete
        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                SessionUserHelper.CreateSessionSuccess(_iServiceRighBanner.Delete(id)
               ? ConstantStrings.DeleteSuccess
               : ConstantStrings.DeleteNonSuccess);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw;
            }

        }
        #endregion
        #region Is Active
        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult Active(int id)
        {
            try
            {
                SessionUserHelper.CreateSessionSuccess(_iServiceRighBanner.IsActive(id)
              ? ConstantStrings.UpdateActiveSuccess
              : ConstantStrings.UpdateActiveFail);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion
        #region Update STT
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult UpdateSTT(int ID, string STT)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Int32.Parse(STT) <= 0)
                    {
                        SessionUserHelper.CreateSessionError(ConstantStrings.EditNonSuccess);
                        return RedirectToAction("Index");
                    }
                    var model = new RightBanner();
                    model.Id = ID;
                    model.STT = Int32.Parse(STT);

                    if (_iServiceRighBanner.UpdateSTT(model))
                    {
                        SessionUserHelper.CreateSessionSuccess(ConstantStrings.EditSuccess);
                    }
                    else
                    {
                        SessionUserHelper.CreateSessionError(ConstantStrings.EditNonSuccess);
                    }
                    return RedirectToAction("Index");

                }
                SessionUserHelper.CreateSessionError(ConstantStrings.EditNonSuccess);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                SessionUserHelper.CreateSessionError(ConstantStrings.EditNonSuccess);
                return RedirectToAction("Index");
            }

        }
        #endregion
    }
}