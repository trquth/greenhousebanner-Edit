using greenhousebanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenhousebanner.Repository
{
    public interface IUserRepository
    {
        User FindById(Guid id);
        bool Update(User item);
        IEnumerable<User> GetAllUser();
        IEnumerable<User> GetAllActiveUser();
        bool Delete(Guid id);
        bool Add(User item);
        bool IsActive(Guid id);
    }
}
