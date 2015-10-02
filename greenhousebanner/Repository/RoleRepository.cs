using greenhousebanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenhousebanner.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private GreenhouseBannerContext _context;
        public RoleRepository()
        {
            this._context = new GreenhouseBannerContext();
        }
        public IEnumerable<Models.Role> GetAllRole()
        {
            using (_context)
            {
                return _context.Roles.ToList();
            }
        }


        public Role FindById(int id)
        {
            using (_context)
            {
                return _context.Roles.Find(id);
            }
        }
        public bool Add(Role item)
        {
            try
            {
                using (_context)
                {
                    item.IsActive = true;
                    item.IsDelete = false;
                    _context.Roles.Add(item);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Update(Role item)
        {
            try
            {
                using (_context = new GreenhouseBannerContext())
                {
                    Role user = this._context.Roles.FirstOrDefault(c => c.Id == item.Id);
                    if (user != null)
                    {
                        user.RoleName = item.RoleName;
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

        public bool IsActive(int id)
        {
            try
            {
                using (_context = new GreenhouseBannerContext())
                {
                    Role role = _context.Roles.FirstOrDefault(c => c.Id == id);
                    if (role != null)
                    {
                        role.IsActive = !role.IsActive;
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


        public bool Delete(int id)
        {
            try
            {
                using (_context)
                {
                    Role role = _context.Roles.FirstOrDefault(c => c.Id == id);
                    if (role != null)
                    {
                        role.IsDelete = true;
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