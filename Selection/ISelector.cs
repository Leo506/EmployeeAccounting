using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.Selection
{
    public interface ISelector<T>
    {
        List<T> Select(List<T> original);
    }
}
