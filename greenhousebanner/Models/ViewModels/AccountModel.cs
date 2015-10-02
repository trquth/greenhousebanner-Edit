using greenhousebanner.Infrastructures.Helper;
using greenhousebanner.Infrastructures.MD5;
using greenhousebanner.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenhousebanner.Models.ViewModels
{
    public class AccountModel
    {

        private readonly IServiceUser _iServiceUser;
        List<Account> listAccounts = new List<Account>();
        public AccountModel()
        {
            this._iServiceUser = new ServiceUser();
            var model = _iServiceUser.GetAllUserActive();
            listAccounts = GetListAccounts(_iServiceUser.GetAllUserActive());        
        }
        public List<Account> GetListAccounts(IEnumerable<User> listusers)
        {
            List<Account> listAccounts = new List<Account>();
            foreach (var item in listusers)
            {
                var model = new Account();
                model.UserId = item.Id;
                model.Username = item.Username;
                model.Password = MD5Helper.Decrypt(item.Password,true); 
                model.Roles = new string[] {GetNameHelper.GetRoleName(item.IdRole) };
                listAccounts.Add(model);
            }
            return listAccounts;

        }
        public Account Find(string username)
        {
            return listAccounts.Where(acc => acc.Username.Equals(username)).FirstOrDefault();
        }
        public Account Login(string username, string password)
        {
           
            return listAccounts.Where(acc => acc.Username.Equals(username) && acc.Password.Equals(password)).FirstOrDefault(); ;
        }
    }
}