using System;
using System.Web.Mvc;
using System.Web.Security;
using SSC.Core.Api.Models.SSC;
using SSC.Core.Api.Models.Entity;
using System.Web.Configuration;
using greenhousebanner.Infrastructures;
using greenhousebanner.Infrastructures.Helper;
using SSC.Core.Api.Models.Util;

namespace ssc.school.lesson.Controllers
{
    public class AuthController : Controller
    {
       

        private SessionUserHelper.UserSession _userSession;
        public AuthController()
        {

            _userSession = new SessionUserHelper.UserSession();
        }

        //
        // GET: /Auth/
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            var token = Request.QueryString["token"];

            if (string.IsNullOrWhiteSpace(token))
            {
                Response.Redirect(string.Format("{0}/login?return={1}", WebConfigurationManager.AppSettings["AccountUrl"], Request.Url.AbsoluteUri), true);
            }
            else
            {
                var result = WebApiHelper.SscCoreRequest("User/VerifyToken", new TheSscRequest(token));
                if (result.IsNotNull() && result.ResponseCode == TheSscResultCode.LoginByTokenSucceed)
                {
                    var userEntityResponse = result.GetResponse<UserEntity>(0);

                    if (userEntityResponse.IsNotNull())
                    {
                        var typeruser = UserApiHelper.GetUserTypeByUser(userEntityResponse.Id);

                        FormsAuthentication.SetAuthCookie(userEntityResponse.Username, false);
                        if (IsSuccessCreateSessionUser(_userSession, userEntityResponse))
                        {
                            return Redirect("~/Admin");         
                        }
                        Response.Redirect(string.Format("{0}/login?return={1}", WebConfigurationManager.AppSettings["AccountUrl"], Request.Url.AbsoluteUri), true);
                    }
                    else
                        Response.Redirect(string.Format("{0}/login?return={1}", WebConfigurationManager.AppSettings["AccountUrl"], Request.Url.AbsoluteUri), true);
                }
                else
                    Response.Redirect(string.Format("{0}/login?return={1}", WebConfigurationManager.AppSettings["AccountUrl"], Request.Url.AbsoluteUri), true);
            }

            return View();
        }

        private ActionResult CheckToken(string token)
        {
            var result = WebApiHelper.SscCoreRequest("VerifyToken", new TheSscRequest(token));
            if (result.IsNotNull() && result.ResponseCode == TheSscResultCode.LoginByTokenSucceed)
            {
                var UserEntityResponse = result.GetResponse<UserEntity>(0);
                if (UserEntityResponse.IsNotNull())
                {
                    FormsAuthentication.SetAuthCookie(UserEntityResponse.Username, false);
                    //SessionWrapper.Current.UserSession = new Session(UserEntityResponse.Username);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    var SSCHomeUrl = Request.Url.AbsoluteUri;
                    Response.Redirect(SSCHomeUrl.Substring(0, SSCHomeUrl.IndexOf("token", StringComparison.Ordinal) - 1), true);
                    ModelState.AddModelError("", "Phiên đăng nhập của bạn đã quá hạn. Quá trình đăng nhập tự động không thực hiện được. Xin hãy quay về đăng nhập tại trang chủ: " + SSCHomeUrl);
                    return View();
                }
            }
            return View();
        }
        [ActionName("Logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.RemoveAll();
            return Redirect(string.Format("{0}/logout?return={1}", WebConfigurationManager.AppSettings["AccountUrl"], WebConfigurationManager.AppSettings["localUrl"]));
        }

        private bool IsSuccessCreateSessionUser(SessionUserHelper.UserSession userSession,UserEntity userEntityResponse)
        {
            userSession.IsAnonymousUser = false;
            userSession.IsLoggedIn = true;
            userSession.UserEntity = userEntityResponse;

            try
            {
                Session["UserSession"] = userSession;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Error when create UserSession. Error: {0}",ex));
                return false;
            }
        }


    }
}