using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;

namespace EmployeeAccounting.Selection
{
    public class TypeSelector<T> : ISelector<T>
    {
        private string type;

        public TypeSelector(string type)
        {
            this.type = type;
        }

        public List<T> Select(List<T> original)
        {
            return original.Where(t => t.GetType().Name == type).ToList();
        }
    }
}
