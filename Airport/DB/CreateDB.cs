using Airport.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Airport.DB
{
    public class CreateDB
    {
        public SqliteConnection myConnection;
        public CreateDB()
        {
            Database database = new Database();
            myConnection = database.myConnection;
            database.OpenConection();
            CreateCountryTable();
            CreateCompanyTable();
            CreateAircraftTable();
            CreateAircraftModelTable();
            database.CloseConection();

        }
        private void CreateCountryTable()
        {
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = "DROP TABLE IF EXISTS Country";
            myCommand.ExecuteNonQuery();
            myCommand.CommandText = "CREATE TABLE Country (Id INTEGER PRIMARY KEY, Code TEXT NOT NULL, Name TEXT, EUCountry BOOL NOT NULL)";
            myCommand.ExecuteNonQuery();
            AddCountrys();
        }
        private void AddToCountryTable(Country country)
        {
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = $"INSERT INTO Country ( Id, Code, Name, EUCountry) VALUES('{country.Id}', '{country.Code}', '{country.Name}', '{country.EUCountry}')";
            myCommand.ExecuteNonQuery();

        }

        private void CreateCompanyTable()
        {
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = "DROP TABLE IF EXISTS Company";
            myCommand.ExecuteNonQuery();
            myCommand.CommandText = "CREATE TABLE Company (Id INTEGER PRIMARY KEY, Name TEXT, CountryId INTEGER NOT NULL)";
            myCommand.ExecuteNonQuery();
            AddCompanys();
        }
        private void AddToCompanyTable(Company comp)
        {
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = $"INSERT INTO Company ( Id, Name, CountryId) VALUES('{comp.Id}', '{comp.Name}', '{comp.CountryId}')";
            myCommand.ExecuteNonQuery();

        }

        private void CreateAircraftTable()
        {
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = "DROP TABLE IF EXISTS Aircraft";
            myCommand.ExecuteNonQuery();
            myCommand.CommandText = "CREATE TABLE Aircraft (Id INTEGER PRIMARY KEY, ModelId INTEGER NOT NULL, CompanyId INTEGER NOT NULL, SerialNumber TEXT NOT NULL)";
            myCommand.ExecuteNonQuery();
            AddAircrafts();
        }
        private void AddToAircraftTable(Aircraft airc)
        {
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = $"INSERT INTO Aircraft ( Id, ModelId, CompanyId, SerialNumber) VALUES('{airc.Id}', '{airc.ModelId}', '{airc.CompanyId}', '{airc.SerialNumber}')";
            myCommand.ExecuteNonQuery();

        }
        private void CreateAircraftModelTable()
        {
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = "DROP TABLE IF EXISTS AircraftModel";
            myCommand.ExecuteNonQuery();
            myCommand.CommandText = "CREATE TABLE AircraftModel (Id INTEGER PRIMARY KEY, Number TEXT NOT NULL, Description TEXT)";
            myCommand.ExecuteNonQuery();
            AddAircraftModels();
        }
        private void AddToAircraftModelTable(AircraftModel aircm)
        {
            SqliteCommand myCommand = new SqliteCommand("", myConnection);
            myCommand.CommandText = $"INSERT INTO AircraftModel ( Id, Number, Description) VALUES('{aircm.Id}', '{aircm.Number}', '{aircm.Description}')";
            myCommand.ExecuteNonQuery();

        }
        private void AddCountrys()
        {
            using (StreamReader CountryFail = new StreamReader("../../../countries.txt"))
            {   
                string readLine;
                while ((readLine = CountryFail.ReadLine()) != null)
                {
                    String[] value = readLine.Split(',');                    
                    AddToCountryTable(new Country(Int32.Parse(value[0]), value[1], value[2], Boolean.Parse(value[3])));
                }
            }
        }
        private void AddCompanys()
        {
            using (StreamReader CountryFail = new StreamReader("../../../companys.txt"))
            {
                string readLine;
                while ((readLine = CountryFail.ReadLine()) != null)
                {
                    String[] value = readLine.Split(',');
                    AddToCompanyTable(new Company(Int32.Parse(value[0]), value[1], Int32.Parse(value[2])));                    
                }
            }
        }
        private void AddAircrafts()
        {   
            using (StreamReader CountryFail = new StreamReader("../../../aircraft.txt"))
            {
                string readLine;
                while ((readLine = CountryFail.ReadLine()) != null)
                {
                    String[] value = readLine.Split(',');                    
                    AddToAircraftTable(new Aircraft(Int32.Parse(value[0]), Int32.Parse(value[1]), Int32.Parse(value[2]), value[3]));
                }
            }
        }
        private void AddAircraftModels() 
        {
            using (StreamReader CountryFail = new StreamReader("../../../aircraftmodels.txt"))
            {
                string readLine;
                while ((readLine = CountryFail.ReadLine()) != null)
                {
                    String[] value = readLine.Split(',');                    
                    AddToAircraftModelTable(new AircraftModel(Int32.Parse(value[0]), value[1], value[2]));
                }
            }
            
        }
    }
}