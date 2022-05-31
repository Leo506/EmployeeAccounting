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

        public LocalWorker()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            departmentHeads = new List<DepartmentHead>();
            FillHeads();
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
                else
                    toAdd = new Employer(name, date, sex);
                
                employers.Add(toAdd);
            }

            reader.Close();
            reader.Dispose();

            return employers;
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

        ~LocalWorker()
        {
            connection?.Close();
            connection?.Dispose();
        }
    }
}
