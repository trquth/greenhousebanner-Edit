using greenhousebanner.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenhousebanner.Infrastructures.Helper
{
    public class GetNameHelper
    {
        public static string GetRoleName(int id)
        {
            IServiceRole _servicerole = new ServiceRole();
            string name = _servicerole.FindRoleById(id).RoleName.ToString();
            return name ;
        }
    }
}