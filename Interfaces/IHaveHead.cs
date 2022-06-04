using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.Interfaces
{
    public interface IHaveHead
    {
        IHaveDepartment Head { get; set; }
    }
}
