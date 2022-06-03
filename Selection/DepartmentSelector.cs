using EmployeeAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.Selection
{
    public class DepartmentSelector<T> : ISelector<T>
    {
        private string departmentName;

        public DepartmentSelector(string depName)
        {
            departmentName = depName;
        }
        public List<T> Select(List<T> original)
        {
            List<T> toReturn = new List<T>();

            foreach (var employer in original)
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
