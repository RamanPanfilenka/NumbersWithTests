using Dal.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class User: BaseModel
    {
        public string Password { get; set; }

        public bool LogIn = false;
        public string Name { get; set; } = "Guest";
        public int Score { get; set; } = 0;

        public Stats Stats { get; set; }

        public User()
        {

        }

        public User(string name, string login = null, string password = null)
        {
            Name = name;
            Login = login;
            Password = password;
            Stats = new Stats(this.Login);
        }



    }
}
