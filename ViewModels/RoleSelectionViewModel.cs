using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;
using EmployeeAccounting.Selection;

namespace EmployeeAccounting.ViewModels
{
    public class RoleSelectionViewModel
    {
        public static event Action<TypeSelector<EmployeeAccounting.Models.Employer>>? SelectonChooseEvent;

        public string SelectedRole { get; set; }
        public string[] RoleNames { get; private set; }

        public RoleSelectionViewModel()
        {
            RoleNames = new string[] { "Руководитель", "Рабочий", "Директор" };
            SelectedRole = RoleNames[0];
        }

        public void OnSelectorChoose()
        {
            switch (SelectedRole)
            {
                case "Руководитель":
                    TypeSelector<Employer> selector = new TypeSelector<Employer>(nameof(DepartmentHead));
                    SelectonChooseEvent?.Invoke(selector);
                    break;

                case "Рабочий":
                    TypeSelector<Employer> selector1 = new TypeSelector<Employer>(nameof(Worker));
                    SelectonChooseEvent?.Invoke(selector1);
                    break;

                case "Директор":
                    TypeSelector<Employer> selector2 = new TypeSelector<Employer>(nameof(Director));
                    SelectonChooseEvent?.Invoke(selector2);
                    break;
            }
        }


    }
}
