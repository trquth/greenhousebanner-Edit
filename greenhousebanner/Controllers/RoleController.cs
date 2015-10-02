using greenhousebanner.Infrastructures.Helper;
using greenhousebanner.Models;
using greenhousebanner.Models.ViewModels;
using greenhousebanner.Security;
using greenhousebanner.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace greenhousebanner.Controllers
{
    public class RoleController : Controller
    {
        private readonly IServiceRole _iServiceRole;
        public RoleController()
        {
            this._iServiceRole = new ServiceRole();
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(_iServiceRole.GetAllRole());
        }
        #region Create
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                Role model = new Role();
                model.RoleName = role.RoleName;
                if (_iServiceRole.SaveAdd(model))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.AddSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.AddNonSuccess);
                }
                return RedirectToAction("Index");
            }
            return View(role);
        }
        #endregion
        #region Edit
        [CustomAuthorize(Roles = "Admin")]
        public RoleViewModel GetRoleViewModel(int id)
        {
            var model = _iServiceRole.FindRoleById(id);
            var item = new RoleViewModel();
            item.Id = model.Id;
            item.RoleName = model.RoleName;
            return item;
        }

        public Role GetRoleModel(RoleViewModel model)
        {
            var item = new Role();
            item.Id = model.Id;
            item.RoleName = model.RoleName;
            return item;
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(GetRoleViewModel(id));
        }
        [CustomAuthorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                if (_iServiceRole.SaveEdit(GetRoleModel(role)))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.EditSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.EditNonSuccess);
                }
                return RedirectToAction("Index");
            }
            return View(role);
        }
        #endregion
        #region Active
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Active(int id)
        {
            try
            {
                SessionUserHelper.CreateSessionSuccess(_iServiceRole.IsActive(id)
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
        #region Delete
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                SessionUserHelper.CreateSessionSuccess(_iServiceRole.Delete(id)
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
    }
}