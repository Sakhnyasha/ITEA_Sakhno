using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project
{
    public class DBWorker
    {
        static string host = "127.0.0.1";
        static int port = 3306;
        static string db = "final";
        static string username = "root";
        static string password = "";
        public static MySqlConnection getMysqlConnection()
        {
            return MySQLConnector.getConnection(host, port, db, username, password);
        }

        public User getUser()
        {
            return new User();
        }
    }
}
