using greenhousebanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenhousebanner.Service
{
    interface IServiceUser
    {
        bool Delete(Guid id);
        IEnumerable<User> GetAllUser();
        IEnumerable<User> GetAllUserActive();
        User GetItemUser(Guid id);
        bool SaveAdd(User item);
        bool SaveEdit(User item);
        bool IsActive(Guid id);
    }
}
