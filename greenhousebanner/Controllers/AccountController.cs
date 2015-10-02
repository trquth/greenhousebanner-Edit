using greenhousebanner.Models.ViewModels;
using greenhousebanner.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace greenhousebanner.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(AccountViewModel avm)
        {
            AccountModel am = new AccountModel();
            if (string.IsNullOrEmpty(avm.Account.Username) || string.IsNullOrEmpty(avm.Account.Password) || am.Login(avm.Account.Username, avm.Account.Password) == null)
            {
                ViewBag.Error = "Tài khoản không hợp lệ";
                return View("Index");
            }

            SessionPersister.Username = avm.Account.Username;
            Session["Account"] = am.Login(avm.Account.Username, avm.Account.Password) ;
            return RedirectToAction("Index", "Banner");
            //return View("Success");
        }
        public ActionResult LogOut()
        {
            SessionPersister.Username = string.Empty;
            Session["Account"] = null;
            return RedirectToAction("Index");
        }
    }
}