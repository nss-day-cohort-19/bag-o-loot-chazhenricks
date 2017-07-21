using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;

namespace BagOLoot
{
    public class DatabaseInterface
    {
            //format for connecting to a SQLite database
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public DatabaseInterface()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        //checks to make sure that a child table exists
        public void CheckForChildTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the child table to see if table is created
                dbcmd.CommandText = $"select childId from child";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader())
                    {
                        
                    }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table child (
                            `childId`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name`	varchar(80) not null, 
                            `delivered` integer not null default 0
                        )";
                        dbcmd.ExecuteNonQuery ();
                        dbcmd.Dispose ();
                    }
                }
                _connection.Close ();
            }
        }

        //check to make sure a toy table exists
        public void CheckForToyTable ()
        {
            //uses an SQL connection to our BAGOLOOT_DB path
            using (_connection)
            {   
                //opens connection to db
                _connection.Open();
                //stores a sqlite command into variable dbcmd
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the child table to see if table is created
                dbcmd.CommandText = $"select toyId from toy";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader())
                    {
                        
                    }
                    //erases the command from the dbcmd memory
                    dbcmd.Dispose ();
                }
                //if this exceptionis thrown
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        //if the toy table doesnt exist, create it
                        dbcmd.CommandText = $@"create table toy (
                            `toyId`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name`	varchar(80) not null, 
                            `childId` integer NOT NULL,
                            FOREIGN KEY(`childId`) REFERENCES `child`(`childId`)
                        )";
                        //indicates that the command is an action, not a query
                        dbcmd.ExecuteNonQuery ();
                        dbcmd.Dispose ();
                    }
                }
                //closes connection
                _connection.Close ();
            }
        }
    }
}