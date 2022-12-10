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
        public SqliteConnection myConnection;
        public AircraftModelRepository() 
        {
            Database database = new Database();
            myConnection = database.myConnection;
        }
        public List<AircraftModel> Retrieve()
        {
            myConnection.Open();
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = "SELECT * FROM AircraftModel";
            SqliteDataReader results = myCommand.ExecuteReader();
            List<AircraftModel> aircraftModels = new List<AircraftModel>();
            while (results.Read())
            {
                aircraftModels.Add(new AircraftModel(results.GetInt16(0), results.GetString(1), results.GetString(2)));
            }
            myConnection.Close();
            return aircraftModels;
        }

        public AircraftModel Retrieve(int id)
        {
            try
            {
                myConnection.Open();
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = $"SELECT * FROM AircraftModel WHERE Id={id}";

                using (SqliteDataReader results = myCommand.ExecuteReader())
                {
                    if (results.Read())
                    {
                        AircraftModel aircraftModels = new AircraftModel(results.GetInt32(0), results.GetString(1), results.GetString(2));
                        myConnection.Close();
                        return aircraftModels;
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
