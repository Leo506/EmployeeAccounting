﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;
using EmployeeAccounting.DB;
using System.Diagnostics;
using EmployeeAccounting.Roles;

namespace EmployeeAccounting.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged
    {
        public List<Employer> Employers { get; private set; }
        public List<Employer> Heads { get; private set; }

        public string[] AvailableGender { get; private set; }
        public List<IRole> AvailableRole { get; private set; }

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


        private Employer _selectedEmp;
        public Employer SelectedEmployer
        {
            get => _selectedEmp;
            set
            {
                _selectedEmp = value;
                Heads = Employers.Where(e => e.GetType() == typeof(DepartmentHead) && e.FullName != _selectedEmp.FullName).ToList();

                // TODO избавиться от конкретных классов
                Worker? tmp = _selectedEmp as Worker;
                if (tmp != null)
                    SelectedHead = tmp.Head;
                else
                    SelectedHead = Heads.Count > 0 ? Heads[0] : null;
                
                Sex = _selectedEmp.Sex == Gender.M ? "Муж" : "Жен";
                FullName = _selectedEmp.FullName;
                Born = _selectedEmp.DateOfBirth;
                Role = AvailableRole.Where(role => role.Name == _selectedEmp.GetRole().Name).First();
                
                OnPropertyChanged(nameof(SelectedEmployer));
                OnPropertyChanged(nameof(Heads));
                OnPropertyChanged(nameof(DepartmentName));
            }
        }


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


        // TODO завести отдельную переменную
        public string DepartmentName
        {
            get
            {
                // TODO избавиться от конкретных классов
                DepartmentHead? head = _selectedEmp as DepartmentHead;
                return head == null ? "" : head.DepartmentName;
            }
            set
            {
                // TODO избавиться от конкретных классов
                DepartmentHead? head = _selectedEmp as DepartmentHead;
                if (head != null)
                {
                    head.DepartmentName = value;
                    OnPropertyChanged(nameof(DepartmentName));
                }
            }
        }

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
            FullName = _selectedEmp.FullName;
            Born = _selectedEmp.DateOfBirth;

            Heads = Employers.Where(e => e.GetType() == typeof(DepartmentHead) && e.FullName != _selectedEmp.FullName).ToList();
            _selectedHead = Heads.Count > 0 ? Heads[0] : null;

            AvailableGender = new string[] { "Муж", "Жен" };
            AvailableRole = RoleFactory.GetRoles();

            Trace.WriteLine(_selectedEmp.FullName);

            Role = AvailableRole.Where(role => role.Name == _selectedEmp.GetRole().Name).First();

            //UpdateRole();
        }


        // TODO удалить
        private void UpdateRole()
        {
            /*string role = _selectedEmp.GetType().Name;
            switch (role)
            {
                case "Worker":
                    Role = "Рабочий";
                    break;

                case "DepartmentHead":
                    Role = "Руководитель";
                    break;

                case "Director":
                    Role = "Директор";
                    break;

                default:
                    Role = "";
                    break;
            }*/
        }


        public bool EditEmployer()
        {
            Employer employer = _role.GetEmployer(_fullName, _born, _sex, _selectedHead, DepartmentName);

            worker.Edit(_selectedEmp.FullName, employer);

            return true;
        }

        
    }
}
