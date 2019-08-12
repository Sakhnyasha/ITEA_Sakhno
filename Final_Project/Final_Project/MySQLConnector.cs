using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project
{
    public class MySQLConnector
    {
        public static MySqlConnection getConnection(string host, int port, string db, string username, string password)
        {
            //String config = "Server = " + host + "; Database = " + db + "; port = "
            //    + port + "; USer ID = " + username + "; Password = " + password;
            String config = String.Format("Server = {0}; Database = {1}; port = {2}; USer ID = {3}; Password = {4}",
                host, db, port, username, password);
            MySqlConnection conn = new MySqlConnection(config);
            return conn;
        }
    }
}
