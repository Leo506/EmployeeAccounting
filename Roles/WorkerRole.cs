using EmployeeAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.Roles
{
    public class WorkerRole : IRole
    {
        public string Name => "Рабочий";

        public string GetBaseClassName() => nameof(Worker);

        public Employer GetEmployer(string name, DateTime birth, Gender gender, params object[] additionalParams)
        {
            DepartmentHead? head = additionalParams[0] as DepartmentHead;
            if (head == null)
                throw new ArgumentException("First additional parametr must be DepartmentHead");

            return new Worker(name, birth, gender, head);
        }

        public Employer GetEmptyInstance()
        {
            return new Worker("Nobody", DateTime.Now, Gender.M);
        }
    }
}
