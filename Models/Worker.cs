using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Roles;
using EmployeeAccounting.Interfaces;

namespace EmployeeAccounting.Models
{
    public class Worker :  Employer, IHaveHead
    {
        public IHaveDepartment Head { get; set; }

        public Worker(string name, DateTime date, Gender sex, IHaveDepartment head) : base(name, date, sex)
        {
            Head = head;
            role = new WorkerRole();
        }

        public Worker(string name, DateTime date, Gender sex) : base(name, date, sex)
        {
            Head = null;
            role = new WorkerRole();
        }

        public override string ToString()
        {
            return base.ToString() + "\n\nРуководитель:\n" + Head?.ToString();
        }

        public override string GetArgumentsForAdding()
        {
            string sex = Sex == Gender.M ? "M" : "F";
            Employer? head = Head as Employer;
            return $"\"{FullName}\", \"{DateOfBirth.ToString("yyyy-MM-dd")}\", \"{sex}\", \"{head?.FullName}\"";
        }

        public override string GetArgumentForRemove()
        {
            return $"\"{FullName}\"";
        }
    }
}
