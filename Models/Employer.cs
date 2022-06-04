using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Roles;

namespace EmployeeAccounting.Models
{
    public enum Gender
    {
        M,
        F
    }

    public class Employer
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Sex { get; set; }

        public Employer Replacement { get; set; }

        protected IRole role;

        public Employer(string name, DateTime date, Gender sex)
        {
            FullName = name;
            DateOfBirth = date;
            Sex = sex;
        }

        public override string ToString()
        {
            return $"Имя: {FullName}\nДата рождения: {DateOfBirth.ToString("yyyy-MM-dd")}\nПол: {(Sex == Gender.M ? "муж." : "жен.")}";
        }

        public virtual string GetArgumentsForAdding() => "";

        public virtual string GetArgumentForRemove() => "";

        public virtual bool NeedReplacement() => false;

        public IRole GetRole() => role;
    }
}
