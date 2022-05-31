using EmployeeAccounting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting.ViewModels
{
    public class AddingViewModel
    {
        public List<string> DepartmentHeads { get; private set; }

        public AddingViewModel()
        {
            DepartmentHeads = new List<string>();
            foreach (var item in DB.DBFactory.GetWorker().GetDepartmentHeads())
            {
                DepartmentHeads.Add(item.FullName);
            }
        }

        public bool AddNewEmployer(string type, string name, DateTime date, Gender gender, string? depName, string? headName)
        {
            var db = DB.DBFactory.GetWorker();

            try
            {
                switch (type)
                {
                    case "Работник":
                        DepartmentHead head = db.GetDepartmentHeads().Where(h => h.FullName == headName).First();
                        Worker worker = new Worker(name, date, gender, head);
                        db.AddNewWorker(worker);
                        return true;


                    case "Руководитель":
                        DepartmentHead h = new DepartmentHead(name, date, gender, depName);
                        db.AddNewHead(h);
                        return true;
                        break;

                    case "Директор":
                        Director director = new Director(name, date, gender);
                        db.AddNewDirector(director);
                        return true;


                    default:
                        return false;

                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
