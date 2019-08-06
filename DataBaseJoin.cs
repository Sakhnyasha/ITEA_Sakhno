using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace DataBaseJoin
{
    //Задание: реализация основных запросов: SELECT, INSERT, UPDATE, DELETE
    //users (id INT PRIMARY KEY AUTO_INCREMENT, name VARCHAR(15), login VARCHAR(30), password VARCHAR(30), address VARCHAR(30), age INT)
    //orders (id INT PRIMARY KEY AUTO_INCREMENT, num_of_ord INT, user_id INT, FOREIGN KEY(user_id) REFERENCES users(id))

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

        public User() { }
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
        public override string ToString()
        {
            return "Id:" + id + "; Name:" + name + "; Login:" + login + "; Password:" + password + "; Address:" + address + "; Age:" + age;
        }
    }

    class Order
    {
        public int id;
        public int num_of_ord;
        public User user;

        public Order() { }
        public Order(int num_of_ord, User user)
        {
            this.num_of_ord = num_of_ord;
            this.user = user;
        }
        public Order(int id, int num_of_ord, User user)
        {
            this.id = id;
            this.num_of_ord = num_of_ord;
            this.user = user;
        }
        public override string ToString()
        {
            return "ID:" + id + "; Number of orders:" + num_of_ord +  "; User: " + user.ToString();
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

    class OrderController
    {
        MySqlConnection conn;

        public OrderController(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public Order getOrderById(int id)
        {
            Order order = new Order();
            conn.Open();
            string query = "SELECT * FROM users JOIN orders ON users.id = orders.user_id where orders.id = @id";            

            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@id", id));
            command.Prepare();

            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();

                    int userIdO = reader.GetOrdinal("id");
                    int nameO = reader.GetOrdinal("name");
                    int loginO = reader.GetOrdinal("login");
                    int passwordO = reader.GetOrdinal("password");
                    int addressO = reader.GetOrdinal("address");
                    int ageO = reader.GetOrdinal("age");

                    User user = new User();
                    user.id = reader.GetInt32(userIdO);
                    user.name = reader.GetString(nameO);
                    user.login = reader.GetString(loginO);
                    user.password = reader.GetString(passwordO);
                    user.address = reader.GetString(addressO);
                    user.age = reader.GetInt32(ageO);

                    int idO = reader.GetOrdinal("id");
                    int numOfOrdO = reader.GetOrdinal("num_of_ord");

                    order.id = reader.GetInt32(idO);
                    order.num_of_ord = reader.GetInt32(numOfOrdO);
                    order.user = user;
                }
            }
            conn.Close();
            return order;
        }

        public List<Order> GetAllOrders()
        {
            conn.Open();

            List<Order> orderCol = new List<Order>();
            string query = "SELECT * FROM users JOIN orders ON users.id = orders.user_id";
            MySqlCommand command = new MySqlCommand(query, conn);

            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int userIdO = reader.GetOrdinal("id");
                        int nameO = reader.GetOrdinal("name");
                        int loginO = reader.GetOrdinal("login");
                        int passwordO = reader.GetOrdinal("password");
                        int addressO = reader.GetOrdinal("address");
                        int ageO = reader.GetOrdinal("age");

                        User user = new User();
                        user.id = reader.GetInt32(userIdO);
                        user.name = reader.GetString(nameO);
                        user.login = reader.GetString(loginO);
                        user.password = reader.GetString(passwordO);
                        user.address = reader.GetString(addressO);
                        user.age = reader.GetInt32(ageO);

                        int idO = reader.GetOrdinal("id");
                        int numOfOrdO = reader.GetOrdinal("num_of_ord");

                        Order order = new Order();
                        order.id = reader.GetInt32(idO);
                        order.num_of_ord = reader.GetInt32(numOfOrdO);
                        order.user = user;

                        orderCol.Add(order);
                    }
                }
            }
            conn.Close();
            return orderCol;
        }

        public void addOrder(Order order)
        {
            conn.Open();
            string query = "INSERT INTO orders (num_of_ord,user_id) VALUES (@num_of_ord, @user_id)";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@num_of_ord", order.num_of_ord));
            command.Parameters.Add(new MySqlParameter("@user_id", order.user.id));
            command.Prepare();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void updateOrder(Order order)
        {
            conn.Open();
            string query = "UPDATE orders SET num_of_ord = @num_of_ord, user_id = @user_id WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@num_of_ord", order.num_of_ord));
            command.Parameters.Add(new MySqlParameter("@user_id", order.user.id));
            command.Parameters.Add(new MySqlParameter("@id", order.id));
            command.Prepare();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void dellOrderById(int id)
        {
            conn.Open();
            string query = "DELETE FROM orders WHERE orders.id = @id";
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
            printListInfo(userController.GetAllUsers());
            Console.WriteLine("============================");

            //adding new user
            Console.WriteLine("Adding New User");
            userController.addUser(new User("Sveta", "babydoll", "sveta94", "Obolon", 26));
            printListInfo(userController.GetAllUsers());
            Console.WriteLine("============================");

            //updating user
            Console.WriteLine("Updating User");
            userController.updateUser(new User(6, "Vika", "vikusya", "victory000", "Nyvky", 40));
            printListInfo(userController.GetAllUsers());
            Console.WriteLine("============================");

            //deleting by id
            Console.WriteLine("Deleting by ID");
            userController.dellUserById(7);
            printListInfo(userController.GetAllUsers());
            Console.WriteLine("============================");

            ///////////////////////////////////////////////////////////////////////////////////
            OrderController orderController = new OrderController(DBWorker.getMysqlConnection());

            //get by ID
            Console.WriteLine("Get by ID");
            Console.WriteLine(orderController.getOrderById(2));
            Console.WriteLine("============================");

            //add orders in List and show all
            Console.WriteLine("Show All Orders");
            printListInfo(orderController.GetAllOrders());
            Console.WriteLine("============================");

            //adding new order
            Console.WriteLine("Adding New Order");
            orderController.addOrder(new Order(2, userController.getUserById(4)));
            printListInfo(orderController.GetAllOrders());
            Console.WriteLine("============================");

            //updating order
            Console.WriteLine("Updating Order");
            orderController.updateOrder(new Order(3, 3, userController.getUserById(3)));
            printListInfo(orderController.GetAllOrders());
            Console.WriteLine("============================");

            //deleting by id
            Console.WriteLine("Deleting by ID");
            orderController.dellOrderById(5);
            printListInfo(orderController.GetAllOrders());
            Console.WriteLine("============================");

            //чтобы консоль не закрывалась
            Console.ReadKey();
        }

        private static void printListInfo(IEnumerable<Object> list)
        {
            foreach (var el in list)
            {
                Console.WriteLine(el);
            }
        }

    }
}