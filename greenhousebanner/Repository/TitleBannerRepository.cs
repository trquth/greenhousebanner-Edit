using System;
using System.Collections.Generic;
using System.Linq;
using greenhousebanner.Models;
using greenhousebanner.Models.ViewModels;


namespace greenhousebanner.Repository
{
    public class TitleBannerRepository : ITitleBannerRepository
    {
        private GreenhouseBannerContext _context;
        public TitleBannerRepository()
        {
            this._context = new GreenhouseBannerContext();
        }
        public bool Add(Models.TitleRightBanner item)
        {
            try
            {
                using (_context)
                {
                    item.IsActive = true;
                    item.IsDelete = false;
                    item.CreateDate = DateTime.Now;
                    _context.TitleRightBanners.Add(item);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<TitleRightBanner> GetAllTitleBanner()
        {
            using (_context)
            {
                return _context.TitleRightBanners.Where(x => x.IsDelete != true).ToList();
            }
        }


        public TitleRightBanner FindTitleById(int id)
        {
            using (_context)
            {
                return _context.TitleRightBanners.FirstOrDefault(x => x.ID == id);
            }
        }


        public bool Update(TitleRightBanner item)
        {
            try
            {
                using (_context = new GreenhouseBannerContext())
                {
                    TitleRightBanner title = this._context.TitleRightBanners.FirstOrDefault(c => c.ID == item.ID);
                    if (title != null)
                    {
                        var account = System.Web.HttpContext.Current.Session["Account"] as Account;
                        title.UserModifyId = account.UserId;
                        title.Title = item.Title;
                        title.ModifyDate = DateTime.Now;
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


        public bool Delete(int id)
        {
            try
            {
                using (_context)
                {
                    TitleRightBanner title = _context.TitleRightBanners.FirstOrDefault(c => c.ID == id);
                    if (title != null)
                    {
                        var account = System.Web.HttpContext.Current.Session["Account"] as Account;
                        title.UserModifyId = account.UserId;
                        title.IsDelete = true;
                        title.ModifyDate = DateTime.Now;
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
        public bool IsActive(int id)
        {
            try
            {
                using (_context = new GreenhouseBannerContext())
                {
                    TitleRightBanner title = _context.TitleRightBanners.FirstOrDefault(c => c.ID == id);
                    if (title != null)
                    {
                        var account = System.Web.HttpContext.Current.Session["Account"] as Account;
                        title.UserModifyId = account.UserId;
                        title.IsActive = !title.IsActive;
                        title.ModifyDate = DateTime.Now;                 
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


        public IEnumerable<TitleRightBanner> GetAllTitleBannerActive()
        {
            using (_context)
            {
                return _context.TitleRightBanners.Where(x => x.IsDelete != true&&x.IsActive==true).OrderByDescending(x=>x.ID).ToList();
            }
        }
    }
}