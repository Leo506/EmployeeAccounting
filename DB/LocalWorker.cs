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

        public LocalWorker()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
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

                employers.Add(new Employer(name, date, sex));
            }

            reader.Close();
            reader.Dispose();

            return employers;
        }

        ~LocalWorker()
        {
            connection?.Close();
            connection?.Dispose();
        }
    }
}
