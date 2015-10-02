using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using greenhousebanner.Infrastructures.Helper;
using greenhousebanner.Models;
using greenhousebanner.Models.ViewModels;
using greenhousebanner.Repository;
using greenhousebanner.Security;
using greenhousebanner.Service;
using PagedList;

namespace greenhousebanner.Controllers
{
    public class TitleBannerRightController : Controller
    {
        private readonly IServiceTitelBanner _iServiceRighBanner;
        private const int pageSize = 10;
        public TitleBannerRightController()
        {
            this._iServiceRighBanner = new ServiceTitelBanner();
        }
        [CustomAuthorize(Roles = "User,Admin")]

        public ActionResult Index(int? page)
        {
            var model = _iServiceRighBanner.GetAllTitleBanner();
            int pageNumber = page ?? 1;
            var listtitel = model.OrderByDescending(x => x.CreateDate).ThenByDescending(x => x.ID).ToPagedList(pageNumber, pageSize);
            return View(listtitel);
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
        public ActionResult Create(TitelBannerViewModel item)
        {
            if (ModelState.IsValid)
            {
                TitleRightBanner model = new TitleRightBanner();
                model.Title = item.Titel;
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
        public TitelBannerViewModel GetTitleBannerViewModel(int id)
        {
            var model = _iServiceRighBanner.GetItemTitle(id);
            var item = new TitelBannerViewModel();
            item.Id = model.ID;
            item.Titel = model.Title;
            return item;
        }
        public TitleRightBanner GetTitelBannerModel(TitelBannerViewModel model)
        {
            var item = new TitleRightBanner();
            item.ID = model.Id;
            item.Title = model.Titel;
            return item;
        }
        public ActionResult Edit(int id)
        {
            return View(GetTitleBannerViewModel(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult Edit(TitelBannerViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_iServiceRighBanner.SaveEdit(GetTitelBannerModel(model)))
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

    }
}