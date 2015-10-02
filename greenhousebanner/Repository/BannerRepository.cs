using System;
using System.Collections.Generic;
using System.Linq;
using greenhousebanner.Models;

namespace greenhousebanner.Repository
{
    public class BannerRepository : IBannerRepository
    {
        private GreenhouseBannerContext _context = new GreenhouseBannerContext();

        public Banner FindByGuid(Guid guid)
        {
            return null;
        }

        public Banner FindById(int id)
        {
            using (_context = new GreenhouseBannerContext())
            {
                return _context.Banners.FirstOrDefault(c => c.Id == id);
            }
        }

        public bool Update(Banner item)
        {
            try
            {
                using (_context  = new GreenhouseBannerContext())
                {
                    Banner banner = this._context.Banners.FirstOrDefault(c => c.Id == item.Id);
                    if (banner != null)
                    {
                        banner.BannerName = item.BannerName;
                        banner.BannerImage = item.BannerImage;
                        banner.IsActive = item.IsActive;
                        banner.Position = item.Position;
                        banner.Link = item.Link;
                        banner.BannerDescription = item.BannerDescription;
                        banner.DateTimeModify = DateTime.Now;
                        banner.GuidModify = Guid.NewGuid();
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

        public bool DisableByGuid(Guid guid)
        {
            return false;
        }

        public bool Disable(Banner item)
        {
            try
            {
                using (_context = new GreenhouseBannerContext())
                {
                    Banner banner = _context.Banners.FirstOrDefault(c => c.Id == item.Id);
                    if (banner != null)
                    {
                        banner.IsActive = false;
                        banner.DateTimeModify = DateTime.Now;
                        banner.GuidModify = Guid.NewGuid();
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

        public bool DisableById(int id)
        {
            try
            {
                using (_context)
                {
                    Banner banner = _context.Banners.FirstOrDefault(c => c.Id == id);
                    if (banner != null)
                    {
                        banner.IsActive = false;
                        banner.DateTimeModify = DateTime.Now;
                        banner.GuidModify = Guid.NewGuid();
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

        public bool Add(Banner item)
        {
            try
            {
                using (_context = new GreenhouseBannerContext())
                {
                    item.DateTimeCreate = DateTime.Now;
                    item.GuidCreate = Guid.NewGuid();
                    _context.Banners.Add(item);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public IEnumerable<Banner> GetAllBanner()
        {
            using (_context = new GreenhouseBannerContext())
            {
                return this._context.Banners.ToList();
            }
        }



        public IEnumerable<Banner> GetAllActiveBanner()
        {
            using (_context = new GreenhouseBannerContext())
            {
                return this._context.Banners.Where(c => c.IsActive).ToList();
            }
        }


        public IEnumerable<Banner> GetAllActiveBannerByType(int type)
        {
            using (_context = new GreenhouseBannerContext())
            {
                return this._context.Banners.Where(c => c.IsActive&&c.TypeBanner==type).ToList();
            }
        }
    }
}