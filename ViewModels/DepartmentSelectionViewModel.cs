using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Selection;
using EmployeeAccounting.Models;

namespace EmployeeAccounting.ViewModels
{
    public class DepartmentSelectionViewModel
    {
        public static event Action<DepartmentSelector<EmployeeAccounting.Models.Employer>>? SelectonChooseEvent;

        public string SelectedDepartment { get; set; }

        public List<string> DepartmentNames { get; set; }

        public DepartmentSelectionViewModel(EmployerViewModel viewModel)
        {
            DepartmentNames = new List<string>();
            foreach (var employer in viewModel.Employers)
            {
                string depName = "";

                Worker? worker = employer as Worker;
                if (worker != null)
                    depName = worker.Head.DepartmentName;


                DepartmentHead? head = employer as DepartmentHead;
                if (head != null)
                    depName = head.DepartmentName;

                if (depName != "" && !DepartmentNames.Contains(depName))
                    DepartmentNames.Add(depName);
            }

            SelectedDepartment = DepartmentNames[0];
        }

        public void OnChoose()
        {
            DepartmentSelector<Employer> selector = new DepartmentSelector<Employer>(SelectedDepartment);
            SelectonChooseEvent?.Invoke(selector);
        }
    }
}
