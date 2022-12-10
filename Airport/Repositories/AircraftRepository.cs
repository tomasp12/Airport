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
        public SqliteConnection myConnection;
        public AircraftRepository()
        {
            Database database = new Database();
            myConnection = database.myConnection;
        }
        public List<Aircraft> Retrieve()
        {
            myConnection.Open();
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = "SELECT * FROM Aircraft";
            SqliteDataReader results = myCommand.ExecuteReader();
            List<Aircraft> aircraft = new List<Aircraft>();
            while (results.Read())
            {
                aircraft.Add(new Aircraft(results.GetInt32(0), results.GetInt32(1), results.GetInt32(2), results.GetString(3)));
            }
            myConnection.Close();
            return aircraft;
        }

        public Aircraft Retrieve(int id)        
        {
            try
            {
                myConnection.Open();
                SqliteCommand myCommand = new SqliteCommand("", myConnection);
                myCommand.CommandText = $"SELECT * FROM Aircraft WHERE Id={id}";

                using (SqliteDataReader results = myCommand.ExecuteReader())
                {
                    if (results.Read())
                    {
                        Aircraft aircraft = new Aircraft(results.GetInt32(0), results.GetInt32(1), results.GetInt32(2), results.GetString(1));
                        myConnection.Close();
                        return aircraft;
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
