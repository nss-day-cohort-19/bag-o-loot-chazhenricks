using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class SantasHelper
    {
        //establishes connection to Database
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;
        // private List<int> _childToyList;

                public SantasHelper()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        //method will add an item to a childs toy list
        public int AddItemToBag(string toyName, int childId)
        {   
            //when toy is created and added to child bag, return toyId
            // int toyId = 5;
            // return toyId;

            int _toyId = 0;
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Insert the new child
                dbcmd.CommandText = $"insert into toy values (null, '{toyName}', {childId})";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery ();

                // Get the id of the new row
                dbcmd.CommandText = $"select last_insert_rowid()";
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    if (dr.Read()) {
                        _toyId = dr.GetInt32(0);
                    } else {
                        throw new Exception("Unable to insert value");
                    }
                }

                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            return _toyId;
        }

        public void RemoveItemFromBag(int toyId, int childId)
        {
            
        }

        public List<int> GetChildToyList(int childId)
        {
            return new List<int>(){1, 2, 3, 4};
        }

        //will return a list of strings children who are going to receive toys
        public List<string> GetChildrenWhoGetToys()
        {
            return new List<string>(){"Steve", "Chaz", "AARON"};
        }

        //given a childId, will return if that childs toys have been delivered.
        public bool ChildDeliveryStatus(int childId)
        {
            return true;
        }

        
    
    }
}