using greenhousebanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenhousebanner.Repository
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRole();
        Role FindById(int id);
        bool Add(Role item);
        bool Update(Role item);
        bool IsActive(int id);
        bool Delete(int  id);

    }
}
