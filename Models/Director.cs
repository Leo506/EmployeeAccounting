﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.Models
{
    public class Director : Employer
    {
        public Director(string name, DateTime date, Gender sex) : base(name, date, sex)
        { }

        public override string ToString()
        {
            return base.ToString() + "\nДиректор";
        }

        public override string GetArgumentsForAdding()
        {
            string sex = Sex == Gender.M ? "M" : "F";
            return $"\"{FullName}\", \"{DateOfBirth.ToString("yyyy-MM-dd")}\", \"{sex}\"";
        }
    }
}
