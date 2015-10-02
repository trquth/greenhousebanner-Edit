using greenhousebanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenhousebanner.Service
{
    public interface IServiceRole
    {
        IEnumerable<Role> GetAllRole();
        Role FindRoleById(int id);
        bool SaveAdd(Role item);
        Role GetItemRole(int id);
        bool SaveEdit(Role item);
        bool IsActive(int id);
        bool Delete(int id);
    }
}
