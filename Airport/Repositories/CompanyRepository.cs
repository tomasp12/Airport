using Airport.DB;
using Airport.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Repositories
{
    public class CompanyRepository
    {
        public SqliteConnection myConnection;
        public CompanyRepository()
        {
            Database database = new Database();
            myConnection = database.myConnection;
        }
        public List<Company> Retrieve()
        {
            myConnection.Open();
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = "SELECT * FROM Company";
            SqliteDataReader results = myCommand.ExecuteReader();
            List<Company> Company = new List<Company>();
            while (results.Read())
            {
                Company.Add(new Company(results.GetInt32(0), results.GetString(1), results.GetInt32(2) ));
            }
            myConnection.Close();
            return Company;
        }

        public Company Retrieve(int id)
        {
            try
            {
                myConnection.Open();
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = $"SELECT * FROM Company WHERE Id={id}";

                using (SqliteDataReader results = myCommand.ExecuteReader())
                {
                    if (results.Read())
                    {
                        Company Company = new Company(results.GetInt32(0), results.GetString(1), results.GetInt32(2));
                        myConnection.Close();
                        return Company;
                    }
                }
                myConnection.Close();
                return null;
            }
            catch
            {
                myConnection.Close();
                return null;
            }
        }
    }
}
