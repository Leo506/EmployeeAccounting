using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Roles;
using EmployeeAccounting.Interfaces;

namespace EmployeeAccounting.Models
{
    public class DepartmentHead : Employer, IHaveDepartment, INeedReplacement
    {
        public string DepartmentName { get; set; }
        public object Replacement { get; set; }

        public DepartmentHead(string name, DateTime date, Gender gender, string depName) : base(name, date, gender)
        {
            DepartmentName = depName;
            role = new HeadRole();
            Replacement = null;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nПодразделение: {DepartmentName}";
        }

        public override string GetArgumentsForAdding()
        {
            string sex = Sex == Gender.M ? "M" : "F";
            return $"\"{FullName}\", \"{DateOfBirth.ToString("yyyy-MM-dd")}\", \"{sex}\", \"{DepartmentName}\"";
        }

        public override string GetArgumentForRemove()
        {
            Employer? replacement = Replacement as Employer;
            return $"\"{FullName}\", \"{replacement?.FullName}\"";
        }
    }
}
