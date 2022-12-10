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
        public CompanyRepository()
        {         
        }
        public List<Company> Retrieve()
        {
            List<Company> companyList = new List<Company>();
            Database database = new Database();
            try
            {
                database.OpenConection();
                SqliteConnection myConnection = database.myConnection;
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = "SELECT * FROM Company";
                SqliteDataReader readResults = myCommand.ExecuteReader();            
                while (readResults.Read())
                {
                    companyList.Add(new Company(readResults.GetInt32(0), readResults.GetString(1), readResults.GetInt32(2) ));
                }
            }
            finally
            {
                database.CloseConection();
            }
            return companyList;
        }

        public Company Retrieve(int id)
        {
            Company company = null;
            Database database = new Database();
            try
            {
                database.OpenConection();
                SqliteConnection myConnection = database.myConnection;
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = $"SELECT * FROM Company WHERE Id={id}";
                using (SqliteDataReader readResults = myCommand.ExecuteReader())
                {
                    if (readResults.Read())
                    {
                        company = new Company(readResults.GetInt32(0), readResults.GetString(1), readResults.GetInt32(2));                                             
                    }
                }
            }
            finally
            {
                database.CloseConection();                
            }
            return company;
        }
    }
}
