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

        public string GetBaseClassName() => nameof(DepartmentHead);

        public Employer GetEmployer(string name, DateTime birth, Gender gender, params object[] additionalParams)
        {
            string? depName = additionalParams[1] as string;
            if (depName == null)
                throw new ArgumentException("Second additional parametr must be string");

            Employer? replacement = additionalParams[0] as Employer;
            if (replacement == null)
                throw new ArgumentException("First additional parametr mus be Employer");

            DepartmentHead toReturn = new DepartmentHead(name, birth, gender, depName);
            toReturn.Replacement = replacement;

            return toReturn;
        }

        public Employer GetEmptyInstance()
        {
            return new DepartmentHead("Nobody", DateTime.Now, Gender.M, "");
        }
    }
}
