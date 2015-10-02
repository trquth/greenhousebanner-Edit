using greenhousebanner.Infrastructures.MD5;
using greenhousebanner.Models;
using greenhousebanner.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenhousebanner.Repository
{
    public class UserRepository : IUserRepository
    {
        private GreenhouseBannerContext _context;
        public UserRepository()
        {
            this._context = new GreenhouseBannerContext();
        }
        public Models.User FindById(Guid id)
        {
            using (_context)
            {
                return _context.Users.FirstOrDefault(x => x.Id == id);
            }
        }

        public bool Update(Models.User item)
        {
            try
            {
                using (_context = new GreenhouseBannerContext())
                {
                    User user = this._context.Users.FirstOrDefault(c => c.Id == item.Id);
                    if (user != null)
                    {
                        var account = System.Web.HttpContext.Current.Session["Account"] as Account;
                        user.UserModifyId = account.UserId;
                        user.Username = item.Username;
                        user.Name = item.Name;
                        user.Email = item.Email;
                        //user.Password = MD5Helper.Encrypt(item.Password);
                        user.Password = MD5Helper.Encrypt(item.Password, true);
                        user.ModifyDate = DateTime.Now;                       
                        user.IdRole = item.IdRole;
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Models.User> GetAllUser()
        {
            using (_context)
            {
                return _context.Users.Where(x => x.IsDelete == false && x.Role.IsDelete != true && x.Role.IsActive == true).ToList();
            }
        }

        public IEnumerable<Models.User> GetAllActiveUser()
        {
            using (_context = new GreenhouseBannerContext())
            {
                return _context.Users.Where(x => x.IsActive == true&&x.IsDelete!=true).ToList();
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                using (_context)
                {
                    User user = _context.Users.FirstOrDefault(c => c.Id == id);
                    if (user != null)
                    {
                        var account = System.Web.HttpContext.Current.Session["Account"] as Account;
                        user.UserModifyId = account.UserId;
                        user.IsDelete = true;
                        user.ModifyDate = DateTime.Now;
                        _context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Add(Models.User item)
        {
            try
            {
                using (_context)
                {
                    var account = System.Web.HttpContext.Current.Session["Account"] as Account;
                    item.UserCreateId = account.UserId;
                    item.Id = Guid.NewGuid();
                    item.CreateDate = DateTime.Now;
                    item.IsActive = true;
                    _context.Users.Add(item);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #region IsActive
        public bool IsActive(Guid id)
        {
            try
            {
                using (_context = new GreenhouseBannerContext())
                {
                    User user = _context.Users.FirstOrDefault(c => c.Id == id);
                    if (user != null)
                    {
                        user.IsActive = !user.IsActive;
                        user.ModifyDate = DateTime.Now;
                        var account = System.Web.HttpContext.Current.Session["Account"] as Account;
                        user.UserModifyId = account.UserId;
                        _context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion
    }
}