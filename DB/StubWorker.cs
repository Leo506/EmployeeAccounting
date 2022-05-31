using EmployeeAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.DB
{
    public class StubWorker : IDBWorker
    {
        public void AddNewDirector(Director director)
        {
            throw new NotImplementedException();
        }

        public void AddNewHead(DepartmentHead head)
        {
            throw new NotImplementedException();
        }

        public void AddNewWorker(Worker worker)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentHead> GetDepartmentHeads()
        {
            throw new NotImplementedException();
        }

        public List<Employer> GetEmployers()
        {
            return new List<Employer>()
            { 
                new Employer("AAA BBB CCC", new DateTime(1990, 3, 3), Gender.M),
                new Employer("DDD EEE FFF", new DateTime(1999, 5, 5), Gender.F),
                new Employer("GGG HHH III", new DateTime(1989, 6, 6), Gender.M)
            };
        }
    }
}
