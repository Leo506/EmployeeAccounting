using EmployeeAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.Selection
{
    public class DepartmentSelector : ISelector<EmployeeAccounting.Models.Employer>
    {
        private string departmentName;

        public DepartmentSelector(string depName)
        {
            departmentName = depName;
        }
        public List<Employer> Select(List<Employer> original)
        {
            List<Employer> toReturn = new List<Employer>();

            foreach (Employer employer in original)
            {
                Worker? worker = employer as Worker;
                if (worker != null)
                {
                    string? dep = worker?.Head?.DepartmentName;
                    if (dep == departmentName)
                        toReturn.Add(employer);
                }

                DepartmentHead? head = employer as DepartmentHead;
                if (head != null)
                {
                    string dep = head.DepartmentName;
                    if (dep == departmentName)
                        toReturn.Add(employer);
                }
            }

            return toReturn;
        }
    }
}
