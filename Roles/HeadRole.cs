using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;

namespace EmployeeAccounting.Roles
{
    public class HeadRole : IRole
    {
        public string Name => "Руководитель";

        public Employer GetEmployer(string name, DateTime birth, Gender gender, params object[] additionalParams)
        {
            string? depName = additionalParams[1] as string;
            if (depName == null)
                throw new ArgumentException("Second additional parametr must be string");

            return new DepartmentHead(name, birth, gender, depName);
        }
    }
}
