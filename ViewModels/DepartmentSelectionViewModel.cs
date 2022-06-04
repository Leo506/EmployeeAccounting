using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Selection;
using EmployeeAccounting.Models;
using EmployeeAccounting.Interfaces;

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

                IHaveHead? tmpHead = employer as IHaveHead;
                if (tmpHead != null)
                    depName = tmpHead.Head.DepartmentName;


                IHaveDepartment? tmpDep= employer as IHaveDepartment;
                if (tmpDep != null)
                    depName = tmpDep.DepartmentName;

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
