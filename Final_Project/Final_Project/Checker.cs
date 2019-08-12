using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Final_Project
{
    
    public class Checker
    {
        //для вызова запросов к БД
        UserRepository userRepository = new UserRepository(DBWorker.getMysqlConnection());
        
        //получение хэша
        public string GetHash(string password)
        {
            var md5 = MD5.Create();
            string salt = "S0m3R@nd0mSalt";
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(salt + password));
            return Convert.ToBase64String(hash);
        }

        //проверка на совпадение пароля по хэшу
        public bool validateByHash(string password, string hash)
        {
            return GetHash(password).Equals(hash);
        }

        //проверка на аутентификацию (вход пользователя)
        public string getAut(string login, string password)
        {
            User user = userRepository.getUserByLogin(login);
            return user != null && validateByHash(password, user.password) ? "Access" : "Denied";
        }

        //добавление нового пользователя
        public string addAcc(string login, string name, string password, string rePassword, string address, int age, string sex)
        {
            if (userRepository.getUserByLogin(login) != null)
            {
                return "This user already exists";
            }
            if (password != rePassword) return "Passwords do not match";
            userRepository.addUser(new User(name, login, GetHash(password), address, age, sex));
            return "Access";
        }

        //обновление данных пользователя
        public string updateAcc(string login, string name, string password, string rePassword, string address, int age, string sex)
        {
            if (password != rePassword) return "Passwords do not match";
            userRepository.updateUser(new User(name, login, GetHash(password), address, age, sex));
            return "Access";
        }
    }
}
