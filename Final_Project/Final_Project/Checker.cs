using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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
            string validation = validate(login, name, password, rePassword, address, age, sex);

            if (userRepository.getUserByLogin(login) != null)
            {
                return "This user already exists!";
            }

            if (validation.Equals("COMPLETED SUCCESSFULLY!"))
            {
                userRepository.addUser(new User(name, login, GetHash(password), address, age, sex));
                return "Access";
            }
            else return validation;
        }

        //обновление данных пользователя
        public string updateAcc(string login, string name, string password, string rePassword, string address, int age, string sex)
        {
            string validation = validate(login, name, password, rePassword, address, age, sex);
            if (validation.Equals("COMPLETED SUCCESSFULLY!"))
            {
                userRepository.updateUser(new User(name, login, GetHash(password), address, age, sex));
                return "Access";
            }
            else return validation;
        }

        //фронт который стал бэком...
        public bool isValidEmail(string login)
        {
            return !string.IsNullOrWhiteSpace(login) && new Regex(@"^([A-z0-9_\-\.]+)@(([a-z]{1,}\.)+)([a-z]{2,})$").IsMatch(login);
        }
        public bool isValidPass(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && new Regex(@"^\w{8,12}$").IsMatch(password);
        }
        bool isValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && new Regex(@"^[A-z]+(?: [A-z]+)*$").IsMatch(name);
        }
        bool isValidAddress(string address)
        {
            return !string.IsNullOrWhiteSpace(address) && new Regex(@"^\w+(?: \w+)*$").IsMatch(address);
        }
        bool isValidAge(int age)
        {
            return age >= 0 && age <= 200;
        }
        bool isValidSex(string sex)
        {
            return !string.IsNullOrWhiteSpace(sex) && (sex.Equals("Male") || sex.Equals("Female"));
        }

        String validate(string login, string name, string password, string rePassword, string address, int age, string sex)
        {            
            string errorValid = "REGISTRATION ERROR: <br>";
            bool erorrFlag = false;
            // login(email) check
            if (!isValidEmail(login))
            {
                errorValid += "- Wrong type of LOGIN! It should be like: 'example@google.com';<br>";
                erorrFlag = true;
            }
            // pass check
            if (!password.Equals(rePassword))
            {
                errorValid += "- PASSWORD and RE-PASSWORD do not match!;<br>";
                erorrFlag = true;
            }            
            if (!isValidPass(password) || !isValidPass(rePassword))
            {
                errorValid += "- Wrong PASSWORD OR RE-PASSWORD! Password length from 8 to 12 characters;<br>";                
                erorrFlag = true;
            }
            // name check
            if (!isValidName(name))
            {
                errorValid += "- Wrong type of NAME! It should be like: 'Anna' or 'Sakhno Anna'. NO SIGNS!;<br>";
                erorrFlag = true;
            }
            // address check
            if (!isValidAddress(address))
            {
                errorValid += "- Wrong type of ADDRESS! It should be like: 'Kyiv' or 'Kiev, Peremohy av. 93, ap. 56';<br>";
                erorrFlag = true;
            }
            // age check
            if (!isValidAge(age))
            {
                errorValid += "- Wrong AGE! It should be between 0 years and 200 years!;<br>";
                erorrFlag = true;
            }
            //sex check
            if (!isValidSex(sex))
            {
                errorValid += "- Wrong GENDER. It should be 'Male' or 'Female';<br>";
                erorrFlag = true;
            }
            //message
            if (erorrFlag)
            {
                return errorValid;
            }
            else
            {
                return "COMPLETED SUCCESSFULLY!";
            }
        }
    }
}
