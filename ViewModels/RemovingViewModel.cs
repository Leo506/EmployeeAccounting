using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;
using EmployeeAccounting.DB;
using System.ComponentModel;
using EmployeeAccounting.Interfaces;

namespace EmployeeAccounting.ViewModels
{
    public class RemovingViewModel : INotifyPropertyChanged
    {
        public List<Employer> Employers { get; private set; }              // Все сотрудники из базы
        public List<Employer> AvailableReplacement { get; private set; }   // Доступная замена для сотрудника


        #region Selected Employer property
        private Employer _selectedEmployer;
        public Employer SelectedEmployer 
        { 
            get => _selectedEmployer;
            
            set
            {
                _selectedEmployer = value;
                
                SelectReplacement();
                
                OnPropertyChange(nameof(SelectedEmployer));
                OnPropertyChange(nameof(AvailableReplacement));
            }
        
        }
        #endregion


        #region Selected replacement propert
        private Employer _selectedReplacement;
        public Employer SelectedReplacement 
        { 
            get => _selectedReplacement;
            
            set
            {
                _selectedReplacement = value;
                OnPropertyChange(nameof(SelectedReplacement));
            }
        
        }
        #endregion

        IDBWorker worker;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public RemovingViewModel()
        {
            worker = DBFactory.GetWorker();

            Employers = worker.GetEmployers();
            _selectedEmployer = Employers[0];

            SelectReplacement();
        }



        public bool Remove()
        {
            INeedReplacement? tmp = _selectedEmployer as INeedReplacement;
            if (tmp != null)
                tmp.Replacement = _selectedReplacement;

            worker.Remove(_selectedEmployer);

            return true;
        }

        private void SelectReplacement()
        {
            AvailableReplacement = Employers.Where(e => e.GetType() == typeof(DepartmentHead) && e.FullName != SelectedEmployer.FullName).ToList();
            if (AvailableReplacement.Count > 0)
                _selectedReplacement = AvailableReplacement[0];
            else
                _selectedReplacement = new Employer("Nobody", DateTime.Now, Gender.M);
        }

        public bool NeedReplacement()
        {
            return (_selectedEmployer as INeedReplacement) != null;
        }
    }
}
