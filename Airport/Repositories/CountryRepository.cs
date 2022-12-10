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
        public CountryRepository()
        {   
        }
        public List<Country> Retrieve()
        {   
            List<Country> countryList = new List<Country>();
            Database database = new Database();            
            try
            {
                database.OpenConection();
                SqliteConnection myConnection = database.myConnection;                
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = "SELECT * FROM Country";
                SqliteDataReader readResults = myCommand.ExecuteReader();
                while (readResults.Read())
                {
                    bool isEU = readResults["EUCountry"].ToString() == "True" ? true : false;
                    countryList.Add(new Country(readResults.GetInt32(0), readResults.GetString(1), readResults.GetString(2), isEU));
                }
            }                
            finally
            {
                database.CloseConection();
            }
            return countryList;
        }

        public Country Retrieve(int id)
        {
            Country country = null;
            Database database = new Database();
            try
            {
                database.OpenConection();
                SqliteConnection myConnection = database.myConnection;
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = $"SELECT * FROM Country WHERE Id={id}";
                using (SqliteDataReader readResults = myCommand.ExecuteReader())
                {
                    if (readResults.Read())
                    {
                        bool isEU = readResults["EUCountry"].ToString() == "True" ? true : false;
                        country = new Country(readResults.GetInt32(0), readResults.GetString(1), readResults.GetString(2), isEU);
                    }
                }                
            }            
            finally
            {
                database.CloseConection();                
            }
            return country;
        }
    }
}
