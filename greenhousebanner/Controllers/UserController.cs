using greenhousebanner.Infrastructures.Helper;
using greenhousebanner.Models;
using greenhousebanner.Models.ViewModels;
using greenhousebanner.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using greenhousebanner.Infrastructures.MD5;
using PagedList;
using greenhousebanner.Security;

namespace greenhousebanner.Controllers
{
    public class UserController : Controller
    {
        private readonly IServiceUser _iServiceUser;
        private readonly IServiceRole _iServiceRole;
        private const int pageSize = 10;
        public UserController()
        {
            this._iServiceUser = new ServiceUser();
            this._iServiceRole = new ServiceRole();
        }
        #region Method Paging
        public IEnumerable<User> PagingUser(IEnumerable<User> model, int? page)
        {
            int pageNumber = page ?? 1;
            var listuser = model.OrderByDescending(x => x.CreateDate).ThenByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            return listuser;
        }
        #endregion
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index(int? page)
        {
            var model = _iServiceUser.GetAllUser();
            int pageNumber = page ?? 1;
            var listuser = model.OrderByDescending(x => x.CreateDate).ThenByDescending(x => x.Id).ToPagedList(pageNumber, pageSize);
            return View(listuser);

        }
        #region Create

        public ActionResult GetAllRole()
        {
            var model = _iServiceRole.GetAllRole();
            return PartialView("_ListRole", model);
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [CustomAuthorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User();

                user.Username = model.Username;
                user.Password = MD5Helper.Encrypt(model.ConfirmPassword, true);
                user.Name = model.FullName;
                user.Email = model.Email;
                //user.Password = MD5Helper.Encrypt(model.ConfirmPassword);
                user.IdRole = model.IdRole;
                if (_iServiceUser.SaveAdd(user))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.AddSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.AddNonSuccess);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion
        #region Edit
        public ActionResult SelectOptionInEdit(int id)
        {
            var model = _iServiceRole.GetAllRole();
            ViewBag.Id = id;
            return PartialView("_ListRoleInEdit", model);
        }
        public RegisterUserViewModel GetModelRegisterUser(Guid id)
        {
            var model = _iServiceUser.GetItemUser(id);
            var item = new RegisterUserViewModel();
            item.ID = model.Id;
            item.Username = model.Username;
            item.Password = model.Password;
            item.IdRole = model.IdRole;
            item.FullName = model.Name;
            item.Email = model.Email;
            return item;
        }
        public User GetUserModel(RegisterUserViewModel model)
        {
            var item = new User();
            item.Id = model.ID;
            item.Username = model.Username;
            item.Password = model.Password;
            item.IdRole = model.IdRole;
            item.Email = model.Email;
            item.Name = model.FullName;
            return item;
        }
        public bool CheckOldPassword(Guid id, string passworld)
        {
            string pass = _iServiceUser.GetItemUser(id).Password.ToString();
            string olpass = MD5Helper.Decrypt(pass, true);
            if (passworld.Equals(olpass))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            return View(GetModelRegisterUser(id));
        }
        [CustomAuthorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RegisterUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (CheckOldPassword(model.ID, model.OldPassword))
                {
                    if (_iServiceUser.SaveEdit(GetUserModel(model)))
                    {
                        SessionUserHelper.CreateSessionSuccess(ConstantStrings.EditSuccess);
                    }
                    else
                    {
                        SessionUserHelper.CreateSessionError(ConstantStrings.EditNonSuccess);
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.Error = "Mật khẩu cũ không chính xác.";
                return View(model);

            }
            return View(model);
        }
        #endregion
        #region Edit For User

        [CustomAuthorize(Roles = "User,Admin")]
        public ActionResult ChangeInfoUser(Guid id)
        {
            return View(GetModelRegisterUser(id));
        }
        [CustomAuthorize(Roles = "User,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeInfoUser(RegisterUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (CheckOldPassword(model.ID, model.OldPassword))
                {
                    if (_iServiceUser.SaveEdit(GetUserModel(model)))
                    {
                        SessionUserHelper.CreateSessionSuccess(ConstantStrings.EditSuccess);
                    }
                    else
                    {
                        SessionUserHelper.CreateSessionError(ConstantStrings.EditNonSuccess);
                    }
                    var account = System.Web.HttpContext.Current.Session["Account"] as greenhousebanner.Models.ViewModels.Account;
                    if (!account.Username.Equals(model.Username))
                    {
                        return RedirectToAction("LogOut", "Account");
                    }


                    return RedirectToAction("Index", "Banner");
                }
                ViewBag.Error = "Mật khẩu cũ không chính xác.";
                return View(model);

            }
            return View(model);
        }
        #endregion

        #region Delete
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                SessionUserHelper.CreateSessionSuccess(_iServiceUser.Delete(id)
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
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Active(Guid id)
        {
            try
            {
                SessionUserHelper.CreateSessionSuccess(_iServiceUser.IsActive(id)
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