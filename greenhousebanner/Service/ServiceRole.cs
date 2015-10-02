using greenhousebanner.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenhousebanner.Service
{
    public class ServiceRole : IServiceRole
    {
        private IRoleRepository _role;
        public ServiceRole()
        {
            _role = new RoleRepository();
        }
        public IEnumerable<Models.Role> GetAllRole()
        {
            return _role.GetAllRole().Where(x=>x.IsDelete!=true).ToList();
        }


        public Models.Role FindRoleById(int id)
        {
            return _role.FindById(id);
        }


        public bool SaveAdd(Models.Role item)
        {
            return _role.Add(item);
        }


        public Models.Role GetItemRole(int id)
        {
            return _role.FindById(id);
        }


        public bool SaveEdit(Models.Role item)
        {
            return _role.Update(item);
        }


        public bool IsActive(int id)
        {
            return _role.IsActive(id);
        }


        public bool Delete(int id)
        {
            return _role.Delete(id);
        }
    }
}