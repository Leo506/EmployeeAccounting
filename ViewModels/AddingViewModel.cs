using EmployeeAccounting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Interfaces;
using EmployeeAccounting.DB;
using EmployeeAccounting.Roles;

namespace EmployeeAccounting.ViewModels
{
    public class AddingViewModel
    {
        public List<Employer> DepartmentHeads { get; private set; }  // Список руководителей
        public List<IRole> AvailableRoles { get; private set; }      // Доступные должности
        public string[] AvailableGender { get; private set; }        // Доступные пола

        public string FullName { get; set; }        // Имя нового сотрудника

        public DateTime DateOfBirth { get; set; }   // Дата рождения нового сотрудника


        #region Gender property
        private Gender _sex;
        public string Sex
        {
            get => _sex == Gender.M ? "Муж" : "Жен";
            set
            {
                _sex = value == "Муж" ? Gender.M : Gender.F;
            }
        }
        #endregion

        public Employer? SelectedHead { get; set; }   // Выбранный начальник(руководитель)
        public string DepartmentName { get; set; }    // Название подразделения сотрудника


        public bool NeedHead()
        {
            Employer tmp = Role.GetEmptyInstance();
            return (tmp as IHaveHead) != null;
        }

        public bool NeedDepartment()
        {
            Employer tmp = Role.GetEmptyInstance();
            return (tmp as IHaveDepartment) != null;
        }

        public IRole Role { get; set; }

        private IDBWorker worker;

        public AddingViewModel()
        {
            worker = DBFactory.GetWorker();
            DepartmentHeads = new List<Employer>();
            foreach (var item in worker.GetEmployers())
            {
                IHaveDepartment? tmp = item as IHaveDepartment;
                if (tmp != null)
                    DepartmentHeads.Add(item);
            }

            AvailableRoles = RoleFactory.GetRoles();
            Role = AvailableRoles[0];
            SelectedHead = DepartmentHeads.Count == 0 ? null : DepartmentHeads[0];

            AvailableGender = new string[] { "Муж", "Жен" };

            DepartmentName = "";
        }

        public bool AddNewEmployer()
        {
            Employer tmp = Role.GetEmployer(FullName, DateOfBirth, _sex, SelectedHead == null ? Employer.Nobody : SelectedHead, DepartmentName);
            worker.AddNewRecord(tmp);
            return true;
        }
    }
}
