using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;
using EmployeeAccounting.DB;

namespace EmployeeAccounting.ViewModels
{
    public class RemovingViewModel
    {
        public List<string> EmployerNames { get; private set; }
        public List<string> HeadsNames { get; private set; }
        public List<Employer> Employers { get; private set; }

        private IDBWorker worker;

        public RemovingViewModel()
        {
            worker = DBFactory.GetWorker();
            Employers = worker.GetEmployers();
            EmployerNames = Employers.Select(e => e.FullName).ToList();
            HeadsNames = worker.GetDepartmentHeads().Select(h => h.FullName).ToList();
        }

        public bool IsHead(Employer employer)
        {
            return employer.GetType() == typeof(DepartmentHead);
        }

        public void RemoveEmployer(string removeName, string? replaceName)
        {
            Employer toRemove = Employers.Where(e => e.FullName == removeName).First();

            toRemove.Replacement = Employers.Where(e => e.FullName == replaceName).First();

            worker.Remove(toRemove);
        }
    }
}
