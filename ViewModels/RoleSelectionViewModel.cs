using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;
using EmployeeAccounting.Selection;
using EmployeeAccounting.Roles;

namespace EmployeeAccounting.ViewModels
{
    public class RoleSelectionViewModel
    {
        public static event Action<TypeSelector<EmployeeAccounting.Models.Employer>>? SelectonChooseEvent;

        public IRole SelectedRole { get; set; }
        public List<IRole> RoleNames { get; private set; }

        public RoleSelectionViewModel()
        {
            RoleNames = RoleFactory.GetRoles();
            SelectedRole = RoleNames[0];
        }

        public void OnSelectorChoose()
        {
            TypeSelector<Employer> selector = new TypeSelector<Employer>(SelectedRole.GetBaseClassName());
            SelectonChooseEvent?.Invoke(selector);
        }


    }
}
