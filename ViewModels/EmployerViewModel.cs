using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;
using EmployeeAccounting.DB;
using EmployeeAccounting.Selection;

namespace EmployeeAccounting.ViewModels
{
    public class EmployerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Employer> Employers { get; private set; }

        private Employer _selectedEmp;
        public Employer SelectedEmployer
        {
            get { return _selectedEmp; }
            set
            {
                _selectedEmp = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedEmployer)));
            }
        }

        IDBWorker worker;

        public EmployerViewModel()
        {
            worker = DBFactory.GetWorker();
            Employers = worker.GetEmployers();
            _selectedEmp = Employers[0];

            RoleSelectionViewModel.SelectonChooseEvent += OnSelection;
            DepartmentSelectionViewModel.SelectonChooseEvent += OnSelection;
        }

        public void OnSelection(ISelector<Employer> selector)
        {
            Employers = selector.Select(Employers);
        }

        

        public string? GetInfo(string name)
        {
            return Employers.Where(e => e.FullName == name)?.FirstOrDefault()?.ToString();
        }

        public void UpdateData()
        {
            Employers = DB.DBFactory.GetWorker().GetEmployers();
            _selectedEmp = Employers[0];
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedEmployer)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Employers)));
        }
    }
}
