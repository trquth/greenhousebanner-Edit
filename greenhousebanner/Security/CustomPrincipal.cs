using greenhousebanner.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace greenhousebanner.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Account account;

        public CustomPrincipal(Account account)
        {
            this.account = account;
            if (account == null)
            {
                this.Identity = null;
            }
            else
            {
                this.Identity = new GenericIdentity(account.Username);
            }

        }
        public IIdentity Identity
        {
            get;
            set;
        }
        public bool IsInRole(string role)
        {
            try
            {
                var roles = role.Split(new char[] { ',' });
                return roles.Any(r => this.account.Roles.Contains(r));
            }
            catch (Exception e)
            {

                return false;
            }



        }
    }
}