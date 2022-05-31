using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.DB
{
    public class DBFactory
    {
        public static IDBWorker GetWorker() => new StubWorker();
    }
}
