using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;

namespace EmployeeAccounting.Roles
{
    public class DirectorRole : IRole
    {
        public string Name => "Директор";

        public string GetBaseClassName() => nameof(Director);

        public Employer GetEmployer(string name, DateTime birth, Gender gender, params object[] additionalParams)
        {
            return new Director(name, birth, gender);
        }
    }
}
