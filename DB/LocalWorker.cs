using System;
using System.Collections.Generic;
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

            string sql = "call GetAllEmployers();";
            MySqlCommand command = new MySqlCommand(sql, connection);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString("FullName");
                DateTime date = reader.GetDateTime("DateOfBirth");
                Gender sex = reader.GetString("Sex") == "M" ? Gender.M : Gender.F;

                Employer toAdd;
                if (departmentHeads.Select(h => h.FullName).Contains(name))
                    toAdd = departmentHeads.Where(h => h.FullName == name).First();
                else if (directors.Select(h => h.FullName).Contains(name))
                    toAdd = directors.Where(h => h.FullName == name).First();
                else
                    toAdd = workers.Where(h => h.FullName == name).First();
                
                employers.Add(toAdd);
            }

            reader.Close();
            reader.Dispose();

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

        public void AddNewWorker(Worker worker)
        {
            string sql = $"call AddNewWorker(\"{worker.FullName}\", \"{worker.DateOfBirth.ToString("yyyy-MM-dd")}\", \"{worker.Sex}\", \"{worker.Head.FullName}\");";
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();
        }

        public void AddNewHead(DepartmentHead head)
        {
            string sql = $"call AddNewDepartmentHead(\"{head.FullName}\", \"{head.DateOfBirth.ToString("yyyy-MM-dd")}\", \"{head.Sex}\", \"{head.DepartmentName}\");";
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();
        }

        public void AddNewDirector(Director director)
        {
            string sql = $"call AddNewDirector(\"{director.FullName}\", \"{director.DateOfBirth.ToString("yyyy-MM-dd")}\", \"{director.Sex}\");";
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();
        }

        ~LocalWorker()
        {
            connection?.Close();
            connection?.Dispose();
        }
    }
}
