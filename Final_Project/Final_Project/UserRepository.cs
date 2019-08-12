using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project
{
    public class UserRepository
    {
        MySqlConnection conn;
        public UserRepository(MySqlConnection conn)
        {
            this.conn = conn;
        }

        //получение пользователя по логину
        public User getUserByLogin(string login)
        {
            User user = null;
            conn.Open();
            string query = "SELECT * FROM users WHERE login = @login";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@login", login));
            command.Prepare();

            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    user = new User();
                    reader.Read();
                    int idO = reader.GetOrdinal("id");
                    int nameO = reader.GetOrdinal("name");
                    int loginO = reader.GetOrdinal("login");
                    int passwordO = reader.GetOrdinal("password");
                    int addressO = reader.GetOrdinal("address");
                    int ageO = reader.GetOrdinal("age");
                    int sexO = reader.GetOrdinal("sex");

                    user.id = reader.GetInt32(idO);
                    user.name = reader.GetString(nameO);
                    user.login = reader.GetString(loginO);
                    user.password = reader.GetString(passwordO);
                    user.address = reader.GetString(addressO);
                    user.age = reader.GetInt32(ageO);
                    user.sex = reader.GetString(sexO);
                }
            }
            conn.Close();
            return user;
        }

        //вывод всех пользователей. не использован. на будущее
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
                        int sexO = reader.GetOrdinal("sex");

                        User user = new User();
                        user.id = reader.GetInt32(idO);
                        user.name = reader.GetString(nameO);
                        user.login = reader.GetString(loginO);
                        user.password = reader.GetString(passwordO);
                        user.address = reader.GetString(addressO);
                        user.age = reader.GetInt32(ageO);
                        user.sex = reader.GetString(sexO);

                        userCol.Add(user);
                    }
                }
            }
            conn.Close();
            return userCol;
        }

        //добавление пользователя
        public void addUser(User user)
        {
            conn.Open();
            string query = "INSERT INTO users (name, login, password, address, age, sex) VALUES (@name, @login, @password, @address, @age, @sex)";
            MySqlCommand command = new MySqlCommand(query, conn);

            command.Parameters.Add(new MySqlParameter("@name", user.name));
            command.Parameters.Add(new MySqlParameter("@login", user.login));
            command.Parameters.Add(new MySqlParameter("@password", user.password));
            command.Parameters.Add(new MySqlParameter("@address", user.address));
            command.Parameters.Add(new MySqlParameter("@age", user.age));
            command.Parameters.Add(new MySqlParameter("@sex", user.sex));

            command.Prepare();
            command.ExecuteNonQuery();

            conn.Close();
        }

        //изменение данных о пользователе
        public void updateUser(User user)
        {
            conn.Open();
            string query = "UPDATE users SET name = @name, password = @password, address = @address, age = @age, sex = @sex WHERE login = @login";
            MySqlCommand command = new MySqlCommand(query, conn);

            command.Parameters.Add(new MySqlParameter("@name", user.name));
            command.Parameters.Add(new MySqlParameter("@login", user.login));
            command.Parameters.Add(new MySqlParameter("@password", user.password));
            command.Parameters.Add(new MySqlParameter("@address", user.address));
            command.Parameters.Add(new MySqlParameter("@age", user.age));
            command.Parameters.Add(new MySqlParameter("@sex", user.sex));
            command.Prepare();
            command.ExecuteNonQuery();
            conn.Close();
        }

        //удаление пользователя. не использован. на будущее
        public void dellUserByLogin(string login)
        {
            conn.Open();
            string query = "DELETE FROM users WHERE login = @login";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@login", login));
            command.Prepare();
            command.ExecuteNonQuery();
            conn.Close();
        }

    }
}
