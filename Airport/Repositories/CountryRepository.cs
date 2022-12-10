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
    internal class CountryRepository
    {
        public SqliteConnection myConnection;
        public CountryRepository()
        {
            Database database = new Database();
            myConnection = database.myConnection;
        }
        public List<Country> Retrieve()
        {
            myConnection.Open();
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = "SELECT * FROM Country";
            SqliteDataReader results = myCommand.ExecuteReader();
            List<Country> Country = new List<Country>();
            while (results.Read())
            {

                bool eu = results["EUCountry"].ToString() == "True" ? true: false;                
                Country.Add(new Country(results.GetInt32(0), results.GetString(1), results.GetString(2), eu));
                
            }
            myConnection.Close();
            return Country;
        }

        public Country Retrieve(int id)
        {
            try
            {
                myConnection.Open();
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = $"SELECT * FROM Country WHERE Id={id}";

                using (SqliteDataReader results = myCommand.ExecuteReader())
                {
                    if (results.Read())
                    {
                        bool eu = results["EUCountry"].ToString() == "True" ? true : false;
                        Country Country = new Country(results.GetInt32(0), results.GetString(1), results.GetString(2), eu);
                        myConnection.Close();
                        return Country;
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
