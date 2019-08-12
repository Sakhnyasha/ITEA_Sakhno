using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project
{
    public class User
    {
        public int id;
        public string name;
        public string login;
        public string password;
        public string address;
        public int age;
        public string sex;

        public User(string name, string login, string password, string address, int age, string sex)
        {
            this.name = name;
            this.login = login;
            this.password = password;
            this.address = address;
            this.age = age;
            this.sex = sex;
        }

        public User()
        {
        }

        public override string ToString()
        {
            return "Id:" + id + "; Name:" + name + "; Login:" + login + "; Password:" + password + "; Address:" + address + "; Age:" + age + "; Sex:" + sex;
        }
    }
}
