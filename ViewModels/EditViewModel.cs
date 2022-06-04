using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;
using EmployeeAccounting.DB;
using System.Diagnostics;
using EmployeeAccounting.Roles;
using EmployeeAccounting.Interfaces;

namespace EmployeeAccounting.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged
    {
        public List<Employer> Employers { get; private set; }     // Все сотрудники в базе
        public List<Employer> Heads { get; private set; }         // Все руководители подразделений, доступные при выбранном сотруднике

        public string[] AvailableGender { get; private set; }     // Доступные полы сотрудников
        public List<IRole> AvailableRole { get; private set; }    // Доступные роли (должности сотрудников)


        #region FullName property
        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        #endregion


        #region Born (Date of birth) property
        private DateTime _born;
        public DateTime Born
        {
            get => _born;
            set
            {
                _born = value;
                OnPropertyChanged(nameof(Born));
            }
        }
        #endregion


        #region Selected Employer property
        private Employer _selectedEmp;
        public Employer SelectedEmployer
        {
            get => _selectedEmp;
            set
            {
                _selectedEmp = value;

                SelectHead();
                
                Sex = _selectedEmp.Sex == Gender.M ? "Муж" : "Жен";
                FullName = _selectedEmp.FullName;
                Born = _selectedEmp.DateOfBirth;
                
                SelectRole();
                
                OnPropertyChanged(nameof(SelectedEmployer));
                OnPropertyChanged(nameof(Heads));
                OnPropertyChanged(nameof(DepartmentName));
            }
        }
        #endregion


        #region Selected Department Head property
        private Employer? _selectedHead;
        public Employer? SelectedHead
        {
            get => _selectedHead;
            set
            {
                _selectedHead = value;
                OnPropertyChanged(nameof(SelectedHead));
            }
        }
        #endregion


        #region Gender property
        private Gender _sex;
        public string Sex
        {
            get => _sex == Gender.M ? "Муж" : "Жен";
            set
            {
                _sex = value == "Муж" ? Gender.M : Gender.F;
                OnPropertyChanged(nameof(Sex));
            }
        }
        #endregion


        #region Role property
        private IRole _role;
        public IRole Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
        #endregion


        public string DepartmentName { get; set; }                 // Название подразделения


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        IDBWorker worker;

        public EditViewModel()
        {
            worker = DBFactory.GetWorker();
            Employers = worker.GetEmployers();
            
            _selectedEmp = Employers[0];
            
            _fullName = _selectedEmp.FullName;
            _born = _selectedEmp.DateOfBirth;

            SelectHead();

            AvailableGender = new string[] { "Муж", "Жен" };
            AvailableRole = RoleFactory.GetRoles();

            SelectRole();
        }


        public bool EditEmployer()
        {
            Employer employer = _role.GetEmployer(_fullName, _born, _sex, _selectedHead, DepartmentName);

            worker.Edit(_selectedEmp.FullName, employer);

            return true;
        }


        private void SelectHead()
        {
            Heads = Employers.Where(e => (e as IHaveDepartment) != null && e.FullName != _selectedEmp.FullName).ToList();

            IHaveHead? tmp = _selectedEmp as IHaveHead;
            if (tmp != null)
                SelectedHead = tmp.Head as Employer;
            else
                SelectedHead = Heads.Count > 0 ? Heads[0] : null;
        }

        private void SelectRole()
        {
            Role = AvailableRole.Where(role => role.Name == _selectedEmp.GetRole().Name).First();
        }
        
    }
}
