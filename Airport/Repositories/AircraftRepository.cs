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
    public class AircraftRepository
    {
        public AircraftRepository()
        {        
        }
        public List<Aircraft> Retrieve()
        {
            List<Aircraft> aircraftList = new List<Aircraft>();
            Database database = new Database();
            try 
            {
                database.OpenConection();
                SqliteConnection myConnection = database.myConnection;
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = "SELECT * FROM Aircraft";
                SqliteDataReader readResults = myCommand.ExecuteReader();
                while (readResults.Read())
                {
                    aircraftList.Add(new Aircraft(readResults.GetInt32(0), readResults.GetInt32(1), readResults.GetInt32(2), readResults.GetString(3)));
                }
            }
            finally 
            {
                database.CloseConection();
            }
            return aircraftList;
        }

        public Aircraft Retrieve(int id)        
        {
            Aircraft aircraft = null;
            Database database = new Database();
            try
            {
                database.OpenConection();
                SqliteConnection myConnection = database.myConnection;
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = $"SELECT * FROM Aircraft WHERE Id={id}";
                using (SqliteDataReader readResults = myCommand.ExecuteReader())
                {
                    if (readResults.Read())
                    {
                        aircraft = new Aircraft(readResults.GetInt32(0), readResults.GetInt32(1), readResults.GetInt32(2), readResults.GetString(1));
                    }
                }
            }
            finally
            {
                database.CloseConection();  
            }                
            return aircraft;                     
        }
    }
}
