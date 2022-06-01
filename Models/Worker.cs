using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.Models
{
    public class Worker : Employer
    {
        public DepartmentHead? Head { get; set; }

        public Worker(string name, DateTime date, Gender sex, DepartmentHead head) : base(name, date, sex)
        {
            Head = head;
        }

        public Worker(string name, DateTime date, Gender sex) : base(name, date, sex)
        {
            Head = null;
        }

        public override string ToString()
        {
            return base.ToString() + "\n\nРуководитель:\n" + Head?.ToString();
        }

        public override string GetArgumentsForAdding()
        {
            string sex = Sex == Gender.M ? "M" : "F";
            return $"\"{FullName}\", \"{DateOfBirth.ToString("yyyy-MM-dd")}\", \"{sex}\", \"{Head?.FullName}\"";
        }
    }
}
