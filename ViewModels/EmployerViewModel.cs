using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;

namespace EmployeeAccounting.ViewModels
{
    public class EmployerViewModel
    {
        public List<Employer> Employers { get; private set; }

        public EmployerViewModel()
        {
            Employers = DB.DBFactory.GetWorker().GetEmployers();
        }
    }
}
