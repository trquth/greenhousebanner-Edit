using greenhousebanner.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;


namespace greenhousebanner.Security
{
    public class CustomAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
      
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Username))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Index" }));
            }
            else
            {
                AccountModel am = new AccountModel();
                CustomPrincipal mp = new CustomPrincipal(am.Find(SessionPersister.Username));
                if (!mp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AccessDenied", action = "Index" }));
                }
            }
        }
    }
}