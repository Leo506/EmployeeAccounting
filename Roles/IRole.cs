using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;

namespace EmployeeAccounting.Roles
{
    public interface IRole
    {
        Employer GetEmployer(string name, DateTime birth, Gender gender, params object[] additionalParams);

        string GetBaseClassName();

        Employer GetEmptyInstance();

        string Name { get; }
    }
}
