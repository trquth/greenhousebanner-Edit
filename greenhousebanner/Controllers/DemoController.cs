using greenhousebanner.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace greenhousebanner.Controllers
{
    public class DemoController : Controller
    {     
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [CustomAuthorize(Roles="superadmin,employee")]
        public ActionResult Worlk1()
        {
            return View("Worlk1");
        }
          [CustomAuthorize(Roles = "superadmin")]
        public ActionResult Worlk2()
        {
            return View("Worlk2");
        }

      
    }
}