using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using ssc.school.lesson.Infrastructures.Helper;
using SSC.Core.Api.Models.Entity;
using SSC.Core.Api.Models.Util;

namespace greenhousebanner.Infrastructures.Helper
{
    public class SessionUserHelper : IHttpHandler, IReadOnlySessionState
    {
        public class UserSession
        {
            public bool IsLoggedIn { get; set; }
            public bool IsAnonymousUser { get; set; }
            public UserEntity UserEntity { get; set; }
            public bool IsSysAdmin
            {
                get
                {
                    return UserApiHelper.CheckUserIsSysAdmin(UserEntity.Id);
                }
            }
        }

        private readonly UserSession _session;

        public SessionUserHelper()
        {
            try
            {
                _session = (UserSession)HttpContext.Current.Session["UserSession"];
            }
            catch (Exception ex)
            {
                 Logger.Error(string.Format("Error Acess Session. Error: {0}", ex));
                _session = new UserSession();
            }
            
        }
        /// <summary>
        /// Log out user(Clear working sessions and redirect to login page.)
        /// </summary>
        public void Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Session.RemoveAll();
                HttpContext.Current.Response.Redirect(string.Format("{0}/logout?return={1}", WebConfigurationManager.AppSettings["AccountUrl"], WebConfigurationManager.AppSettings["localUrl"]));
            }
            catch (Exception)
            {
               // Logger.Error(string.Format("Error Acess Session. Error: {0}", ex));
            }
        }

        /// <summary>
        /// Check user authenticated
        /// </summary>
        /// <returns></returns>
        public bool IsLoggedInUser()
        {
            try
            {
              return  _session.IsLoggedIn;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Error Acess Session. Error: {0}", ex));
                return false;
            }
        }

        /// <summary>
        /// Get username of user after user logged in system
        /// </summary>
        /// <returns></returns>
        public string UserName()
        {
            try
            {
                return _session.UserEntity.Username;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Error Acess Session. Error: {0}", ex));
                this.Logout();
               
                return null;
            }
           
        }

        public UserEntity UserEntity()
        {
            try
            {
                return _session.UserEntity;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Error Acess Session. Error: {0}", ex));
                this.Logout();
                return null;
            }
            
        }

        public bool IsValidUserEntity(UserEntity userEntity)
        {
            var type = GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var hasProperty = properties.Select(x => x.GetValue(this, null))
                                        .Any(x => !x.IsNull());
            return !hasProperty;
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public bool IsReusable { get; private set; }
        public void Execute(RequestContext requestContext)
        {
            throw new NotImplementedException();
        }

        public static void CreateSessionError(string error)
        {
            HttpContext.Current.Session["PageTransaction"] = new PageTransactionSession
            {
                IsSuccess = false,
                Message = error
            };
        }

        public static void CreateSessionSuccess(string success)
        {
            HttpContext.Current.Session["PageTransaction"] = new PageTransactionSession
            {
                IsSuccess = true,
                Message = success
            };
        }
    }
}