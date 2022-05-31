using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.Models
{
    public enum Gender
    {
        M,
        F
    }

    public class Employer
    {
        public string FullName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Sex { get; private set; }

        public Employer(string name, DateTime date, Gender sex)
        {
            FullName = name;
            DateOfBirth = date;
            Sex = sex;
        }
    }
}
