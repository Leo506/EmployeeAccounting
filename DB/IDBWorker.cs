using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;

namespace EmployeeAccounting.DB
{
    public interface IDBWorker
    {
        List<Employer> GetEmployers();
    }
}
