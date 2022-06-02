using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;
using EmployeeAccounting.DB;
using System.ComponentModel;

namespace EmployeeAccounting.ViewModels
{
    public class RemovingViewModel : INotifyPropertyChanged
    {
        public List<Employer> Employers { get; private set; }
        public List<Employer> AvailableReplacement { get; private set; }


        private Employer _selectedEmployer;
        public Employer SelectedEmployer 
        { 
            get => _selectedEmployer;
            
            set
            {
                _selectedEmployer = value;
                AvailableReplacement = Employers.Where(e => e.GetType() == typeof(DepartmentHead) && e.FullName != SelectedEmployer.FullName).ToList();

                if (AvailableReplacement.Count == 0)
                    SelectedReplacement = null;

                
                OnPropertyChange(nameof(SelectedEmployer));
                OnPropertyChange(nameof(AvailableReplacement));
            }
        
        }


        private Employer? _selectedReplacement;
        public Employer? SelectedReplacement 
        { 
            get => _selectedReplacement;
            
            set
            {
                _selectedReplacement = value;
                OnPropertyChange(nameof(SelectedReplacement));
            }
        
        }

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
            AvailableReplacement = Employers.Where(e => e.GetType() == typeof(DepartmentHead) && e.FullName != SelectedEmployer.FullName).ToList();
            if (AvailableReplacement.Count > 0)
                _selectedReplacement = AvailableReplacement[0];
            else
                _selectedReplacement = new Employer("Nobody", DateTime.Now, Gender.M);
        }


        public bool Remove()
        {
            if (_selectedReplacement == null && _selectedEmployer.NeedReplacement())
                return false;


            _selectedEmployer.Replacement = _selectedReplacement;

            worker.Remove(_selectedEmployer);

            return true;
        }
    }
}
