using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using greenhousebanner.Models;
using greenhousebanner.Models.ViewModels;

namespace greenhousebanner.Repository
{
    public class RightBannerRepository : IRightBannerRepository
    {
        private GreenhouseBannerContext _context;
        public RightBannerRepository()
        {
            this._context = new GreenhouseBannerContext();
        }
        public bool Add(Models.RightBanner item)
        {
            try
            {
                using (_context)
                {
                    item.STT = _context.RightBanners.Count();
                    item.IsActive = true;
                    item.IsDelete = false;
                    item.CreateDate = DateTime.Now;
                    _context.RightBanners.Add(item);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Models.RightBanner> GetAllRightBanner()
        {
            using (_context)
            {
                return _context.RightBanners.Where(x => x.IsDelete != true).ToList();
            }
        }

        public Models.RightBanner FindRightBannerById(int id)
        {
            using (_context)
            {
                return _context.RightBanners.FirstOrDefault(x => x.Id == id);
            }
        }

        public bool Update(Models.RightBanner item)
        {
            try
            {
                using (_context = new GreenhouseBannerContext())
                {
                    RightBanner bannerRight = this._context.RightBanners.FirstOrDefault(c => c.Id == item.Id);
                    if (bannerRight != null)
                    {
                        var account = System.Web.HttpContext.Current.Session["Account"] as Account;
                        bannerRight.UserModifyId = account.UserId;
                        bannerRight.Name = item.Name;
                        bannerRight.PlanName = item.PlanName;
                        bannerRight.Unit = item.Unit;
                        bannerRight.Link = item.Link;
                        bannerRight.ModifyDate = DateTime.Now;
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
                    RightBanner bannerRight = _context.RightBanners.FirstOrDefault(c => c.Id == id);
                    if (bannerRight != null)
                    {
                        var account = System.Web.HttpContext.Current.Session["Account"] as Account;
                        bannerRight.UserModifyId = account.UserId;
                        bannerRight.IsDelete = true;
                        bannerRight.ModifyDate = DateTime.Now;
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
                    RightBanner bannerRight = _context.RightBanners.FirstOrDefault(c => c.Id == id);
                    if (bannerRight != null)
                    {
                        var account = System.Web.HttpContext.Current.Session["Account"] as Account;
                        bannerRight.UserModifyId = account.UserId;
                        bannerRight.IsActive = !bannerRight.IsActive;
                        bannerRight.ModifyDate = DateTime.Now;
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


        public IEnumerable<RightBanner> GetAllRightBannerActive()
        {
            using (_context)
            {
                return _context.RightBanners.Where(x => x.IsDelete != true &&x.IsActive ==true).OrderByDescending(x=>x.STT).ThenByDescending(x=>x.Id).ToList();
            }
        }


        public bool UpdateSTT(RightBanner item)
        {
            try
            {
                using (_context = new GreenhouseBannerContext())
                {
                    RightBanner bannerRight = _context.RightBanners.FirstOrDefault(c => c.Id == item.Id);
                    if (bannerRight != null)
                    {
                        var account = System.Web.HttpContext.Current.Session["Account"] as Account;
                        bannerRight.UserModifyId = account.UserId;
                        bannerRight.STT = item.STT;
                        bannerRight.ModifyDate = DateTime.Now;
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
    }
}