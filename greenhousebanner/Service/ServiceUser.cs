using greenhousebanner.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenhousebanner.Service
{
    public class ServiceUser:IServiceUser
    {
        private readonly IUserRepository _userrepository = new UserRepository();
        public bool Delete(Guid id)
        {
            return _userrepository.Delete(id);
        }

        public IEnumerable<Models.User> GetAllUser()
        {
            return _userrepository.GetAllUser();
        }

        public IEnumerable<Models.User> GetAllUserActive()
        {
            return _userrepository.GetAllActiveUser();
        }

        public Models.User GetItemUser(Guid id)
        {
            return _userrepository.FindById(id);
        }

        public bool SaveAdd(Models.User item)
        {
            return _userrepository.Add(item);
        }

        public bool SaveEdit(Models.User item)
        {
            return _userrepository.Update(item);
        }     
        public bool IsActive(Guid id)
        {
            return _userrepository.IsActive(id);
        }
    }
}