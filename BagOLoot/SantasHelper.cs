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
            try
            {
                using(_connection)
                {
                    _connection.Open();
                    SqliteCommand dbcmd = _connection.CreateCommand ();

                    // Remove row from server database on toyId
                    dbcmd.CommandText = $"DELETE FROM toy where toyId = '{toyId}'";
                    Console.WriteLine(dbcmd.CommandText);
                    dbcmd.ExecuteNonQuery ();

                    // clean up
                    dbcmd.Dispose ();
                    _connection.Close ();
                }
            }
            catch (Microsoft.Data.Sqlite.SqliteException ex)
            {
            Console.WriteLine("An Error Occurred: " + ex.Message);
            }

        }

        //will return a list of ints that contain the ids of the toys a child is going to receive. 
        public List<Toy> GetChildToyList(int childId)
        {
            List<Toy> childToyList = new List<Toy>();

            using(_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                dbcmd.CommandText = $"select toyId, name , childId from toy where childId = '{childId}'";
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        childToyList.Add(new Toy(dr.GetInt32(0), dr[1].ToString(), dr.GetInt32(2)));
                    }
                }
                dbcmd.Dispose();
                _connection.Close();

            } 

            return childToyList;
        }

        //will return a list of strings children who are going to receive toys
        public List<Child> GetChildrenWhoGetToys()
        {
            List<Child> totalChildrenGettingToys = new List<Child>();
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                dbcmd.CommandText = $@"SELECT c.childId, c.name, c.delivered
                                    FROM child c 
                                    INNER JOIN toy t 
                                    ON c.childId = t.childId
                                     GROUP BY c.name;";
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        totalChildrenGettingToys.Add(new Child(dr.GetInt32(0), dr[1].ToString(), dr.GetInt32(2)));
                    }
                }
                dbcmd.Dispose();
                _connection.Close();
            }

            List<Child> childrenGettingToys = new List<Child>();
            foreach(Child child in totalChildrenGettingToys){
                if(childrenGettingToys.Equals(child.ChildId))
                {

                }else
                {
                    childrenGettingToys.Add(child);
                }
            }
            return childrenGettingToys;
        }

        //given a childId, will return if that childs toys have been delivered.
        public bool ChildDeliveryStatus(int childId)
        {
            int deliveryStatus = 0;
            using(_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                dbcmd.CommandText = $"select delivered from child where childId = '{childId}'";
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        deliveryStatus = (dr.GetInt32(0));
                    }
                }
                dbcmd.Dispose();
                _connection.Close();

            } 
            return deliveryStatus != 0;
        }

    }

    
}
