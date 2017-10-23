using System;
using MySql.Data.MySqlClient;
using ProjectC;

namespace ProjectC.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}

/*
Now, after completing the configurations detailed above, we can call
DB.Connection() from anywhere in our application to communicate with your
database! Calling DB.Connection() will run the following code:

public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }

this code creates a new MySqlConnection named conn using the ConnectionString
that contains the required information to interface with our database. It then
returns the conn object. We can call further methods upon this returned conn
object to to interact with our database
*/
