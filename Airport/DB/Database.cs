using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Airport.Models;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;
using static System.Net.Mime.MediaTypeNames;
using System.Transactions;

namespace Airport.DB
{
    public class Database
    {
        public SqliteConnection myConnection;
        private string conectionString = "Data Source=airport.db";
        //private string conectionString = "Data Source=InMemorySample;Mode=Memory;Cache=Shared";
        public Database()
        {
            myConnection = new SqliteConnection(conectionString);                   
        }
        public void OpenConection () 
        {
            if(myConnection.State != System.Data.ConnectionState.Open) 
            {
                myConnection.Open();
            }
        }
        public void CloseConection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
       

    }
}
