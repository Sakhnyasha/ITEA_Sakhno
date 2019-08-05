using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace DataBase
{
    class MySQLConnector
    {
        public static MySqlConnection getConnection(string host, int port, string db, string username, string password)
        {
            String config = "Server = " + host + "; Database = " + db + "; port = "
                + port + "; USer ID = " + username + "; Password = " + password;
            MySqlConnection conn = new MySqlConnection(config);
            return conn;
        }
    }

    class DBWorker
    {
        static string host = "127.0.0.1";
        static int port = 3306;
        static string db = "test";
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

    class User
    {
        public int id;
        public string name;
        public string login;
        public string password;
        public string address;
        public int age;

        public User(string name, string login, string password, string address, int age)
        {
            this.name = name;
            this.login = login;
            this.password = password;
            this.address = address;
            this.age = age;
        }

        public User(int id, string name, string login, string password, string address, int age)
        {
            this.id = id;
            this.name = name;
            this.login = login;
            this.password = password;
            this.address = address;
            this.age = age;
        }

        public User()
        {
        }

        public override string ToString()
        {
            return "Id:" + id + "; Name:" + name + "; Login:" + login + "; Password:" + password + "; Address:" + address + "; Age:" + age;
        }
    }

    class UserController
    {
        MySqlConnection conn;
        public UserController(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public User getUserById(int id)
        {
            User user = new User();
            conn.Open();
            string query = "SELECT * FROM users WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@id", id));
            command.Prepare();

            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    int idO = reader.GetOrdinal("id");
                    int nameO = reader.GetOrdinal("name");
                    int loginO = reader.GetOrdinal("login");
                    int passwordO = reader.GetOrdinal("password");
                    int addressO = reader.GetOrdinal("address");
                    int ageO = reader.GetOrdinal("age");

                    user.id = reader.GetInt32(idO);
                    user.name = reader.GetString(nameO);
                    user.login = reader.GetString(loginO);
                    user.password = reader.GetString(passwordO);
                    user.address = reader.GetString(addressO);
                    user.age = reader.GetInt32(ageO);
                }
            }
            conn.Close();
            return user;
        }

        public List<User> GetAllUsers()
        {
            conn.Open();

            List<User> userCol = new List<User>();
            string query = "SELECT * FROM users";
            MySqlCommand command = new MySqlCommand(query, conn);

            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int idO = reader.GetOrdinal("id");
                        int nameO = reader.GetOrdinal("name");
                        int loginO = reader.GetOrdinal("login");
                        int passwordO = reader.GetOrdinal("password");
                        int addressO = reader.GetOrdinal("address");
                        int ageO = reader.GetOrdinal("age");

                        User user = new User();
                        user.id = reader.GetInt32(idO);
                        user.name = reader.GetString(nameO);
                        user.login = reader.GetString(loginO);
                        user.password = reader.GetString(passwordO);
                        user.address = reader.GetString(addressO);
                        user.age = reader.GetInt32(ageO);

                        userCol.Add(user);
                    }
                }
            }
            conn.Close();
            return userCol;
        }


        public void addUser(User user)
        {
            conn.Open();
            string query = "INSERT INTO users (name, login, password, address, age) VALUES (@name, @login, @password, @address, @age)";
            MySqlCommand command = new MySqlCommand(query, conn);

            command.Parameters.Add(new MySqlParameter("@name", user.name));
            command.Parameters.Add(new MySqlParameter("@login", user.login));
            command.Parameters.Add(new MySqlParameter("@password", user.password));
            command.Parameters.Add(new MySqlParameter("@address", user.address));
            command.Parameters.Add(new MySqlParameter("@age", user.age));

            command.Prepare();
            command.ExecuteNonQuery();

            conn.Close();
        }

        public void updateUser(User user)
        {
            conn.Open();
            string query = "UPDATE users SET name = @name, login = @login, password = @password, address = @address, age = @age WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, conn);

            command.Parameters.Add(new MySqlParameter("@name", user.name));
            command.Parameters.Add(new MySqlParameter("@login", user.login));
            command.Parameters.Add(new MySqlParameter("@password", user.password));
            command.Parameters.Add(new MySqlParameter("@address", user.address));
            command.Parameters.Add(new MySqlParameter("@age", user.age));
            command.Parameters.Add(new MySqlParameter("@id", user.id));
            command.Prepare();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void dellUserById(int id)
        {
            conn.Open();
            string query = "DELETE FROM users WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@id", id));
            command.Prepare();
            command.ExecuteNonQuery();
            conn.Close();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            UserController userController = new UserController(DBWorker.getMysqlConnection());
            //get by ID
            Console.WriteLine("Get by ID");
            Console.WriteLine(userController.getUserById(2));
            Console.WriteLine("============================");

            ////add users in List and show all
            Console.WriteLine("Show All Users");
            printUsers(userController.GetAllUsers());
            Console.WriteLine("============================");

            //adding new user
            Console.WriteLine("Adding New User");
            userController.addUser(new User("Sveta", "babydoll", "sveta94", "Obolon", 26));
            printUsers(userController.GetAllUsers());
            Console.WriteLine("============================");

            //updating user
            Console.WriteLine("Updating User");
            userController.updateUser(new User(6, "Vika", "vikusya", "victory000", "Nyvky", 40));
            printUsers(userController.GetAllUsers());
            Console.WriteLine("============================");

            //deleting by id
            Console.WriteLine("Deleting by ID");
            userController.dellUserById(7);
            printUsers(userController.GetAllUsers());
            Console.WriteLine("============================");

            Console.ReadKey();
        }

        private static void printUsers(IEnumerable<User> users)
        {
            foreach (var u in users)
            {
                Console.WriteLine(u);
            }
        }

    }
}
