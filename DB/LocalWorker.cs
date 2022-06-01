using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAccounting.Models;
using MySql.Data.MySqlClient;

namespace EmployeeAccounting.DB
{
    public class LocalWorker : IDBWorker
    {
        private const string connectionString = "server=127.0.0.1;uid=root;password=26041986;database=employersdb";

        private MySqlConnection? connection;

        private List<DepartmentHead> departmentHeads;
        private List<Director> directors;
        private List<Worker> workers;

        public LocalWorker()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            departmentHeads = new List<DepartmentHead>();
            directors = new List<Director>();
            workers = new List<Worker>();
            FillHeads();
            FillDirectors();
            FillWorkers();
        }

        

        public List<Employer> GetEmployers()
        {

            List<Employer> employers = new List<Employer>();
            employers.AddRange(workers);
            employers.AddRange(departmentHeads);
            employers.AddRange(directors);

            return employers;
        }

        private void FillWorkers()
        {
            string sql = "select * from WorkerInfo;";
            MySqlCommand command = new MySqlCommand(sql, connection);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString("EmpFullName");
                DateTime date = reader.GetDateTime("DateofBirth");
                Gender sex = reader.GetString("Sex") == "M" ? Gender.M : Gender.F;
                string headName = reader.GetString("HeadFullName");

                DepartmentHead head = departmentHeads.Where(h => h.FullName == headName).First();

                workers.Add(new Worker(name, date, sex, head));
            }

            reader.Close();
            reader.Dispose();
        }

        private void FillHeads()
        {
            string sql = "select * from HeadInfo;";
            MySqlCommand command = new MySqlCommand(sql, connection);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString("FullName");
                DateTime date = reader.GetDateTime("DateOfBirth");
                Gender sex = reader.GetString("Sex") == "M" ? Gender.M : Gender.F;
                string depName = reader.GetString("DepartmenName");

                departmentHeads.Add(new DepartmentHead(name, date, sex, depName));
            }

            reader.Close();
            reader.Dispose();
        }

        private void FillDirectors()
        {
            string sql = "select * from DirectorInfo;";
            MySqlCommand command = new MySqlCommand(sql, connection);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString("FullName");
                DateTime date = reader.GetDateTime("DateOfBirth");
                Gender sex = reader.GetString("Sex") == "M" ? Gender.M : Gender.F;

                directors.Add(new Director(name, date, sex));
            }

            reader.Close();
            reader.Dispose();
        }

        public List<DepartmentHead> GetDepartmentHeads()
        {
            return departmentHeads;
        }


        public void AddNewRecord(Employer employer)
        {
            string sql = $"call AddNew{employer.GetType().Name}({employer.GetArgumentsForAdding()});";
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();
        }

        public void Remove(Employer employer)
        {
            string sql = $"call Remove{employer.GetType().Name}({employer.GetArgumentForRemove()});";
            MySqlCommand command = new MySqlCommand(sql, connection);

            Trace.WriteLine("sql: " + sql);

            command.ExecuteNonQuery();
        }

        ~LocalWorker()
        {
            connection?.Close();
            connection?.Dispose();
        }
    }
}
