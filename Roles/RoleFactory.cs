using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.Roles
{
    public class RoleFactory
    {
        public static List<IRole> GetRoles()
        {
            List<IRole> roles = new List<IRole>();
            roles.Add(new WorkerRole());
            roles.Add(new HeadRole());
            roles.Add(new DirectorRole());

            return roles;
        }
    }
}
