using Airport.DB;
using Airport.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Repositories
{
    public class AircraftModelRepository
    {        
        public AircraftModelRepository() 
        {
        }
        public List<AircraftModel> Retrieve()
        {
            List<AircraftModel> aircraftModelsList = new List<AircraftModel>();
            Database database = new Database();
            try
            {
                database.OpenConection();
                SqliteConnection myConnection = database.myConnection;
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = "SELECT * FROM AircraftModel";
                SqliteDataReader readResults = myCommand.ExecuteReader();                
                while (readResults.Read())
                {
                    aircraftModelsList.Add(new AircraftModel(readResults.GetInt16(0), readResults.GetString(1), readResults.GetString(2)));
                }
            }
            finally
            {
                database.CloseConection();
            }
            return aircraftModelsList;
        }

        public AircraftModel Retrieve(int id)
        {
            AircraftModel aircraftModel = null;
            Database database = new Database();
            try
            {
                database.OpenConection();
                SqliteConnection myConnection = database.myConnection;
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = $"SELECT * FROM AircraftModel WHERE Id={id}";
                using (SqliteDataReader readResults = myCommand.ExecuteReader())
                {
                    if (readResults.Read())
                    {
                        aircraftModel = new AircraftModel(readResults.GetInt32(0), readResults.GetString(1), readResults.GetString(2));
                    }
                }
            }
            finally
            {
                database.CloseConection();            
            }
            return aircraftModel;
        }
    }
}
