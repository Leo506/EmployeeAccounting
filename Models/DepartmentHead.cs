﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.Models
{
    public class DepartmentHead : Employer
    {
        public string DepartmentName { get; private set; }

        public DepartmentHead(string name, DateTime date, Gender gender, string depName) : base(name, date, gender)
        {
            DepartmentName = depName;
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
    }
}
