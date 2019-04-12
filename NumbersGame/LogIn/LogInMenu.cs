using Dal.Models;
using NumbersGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Repositorys;
using NumbersGame.Readers;
using NumberGame.Validators;
using NumbersGame.Enum;

namespace NumbersGame.LogIn
{
    public class LogInMenu
    {
        private string Login;
        private string Password;
        private string Name;

        private bool LogIn = false;

        private const int Try = 3;

        UsersRepository UserRepo = new UsersRepository();

        public User GetPlayer()
        {
            var user = UserRepo.Get(null);
            while (!LogIn)
            {
                Console.WriteLine("1 - Login with existing user");
                Console.WriteLine("2 - Create new user");
                Console.WriteLine("3 - Play as a guest");
                var validatorUserEnter = new ValidatorEnterUser();
                var UserChoose = (LogInMenuEnum)ReadInteger.FromConsole(validatorUserEnter);
                Console.Clear();
                switch (UserChoose)
                {
                    case LogInMenuEnum.LogIn:
                        while (!LogIn)
                        {
                            TryLogIn();
                            if (Login == "exit" || Password == "exit") break;
                        }
                        if (Login == "exit" || Password == "exit") break;
                        user = UserRepo.Get(Login);
                        user.LogIn = true;
                        UserRepo.Save(user);
                        Console.WriteLine($"Congratilation, {user.Name}! LogIn is succsesful");
                        break;
                    case LogInMenuEnum.Create:
                        Registration();
                        user = new User(Name, Login, Password);
                        UserRepo.Save(user);
                        Console.WriteLine($"Congratilation, {Name}! Registration is succsesful");
                        Console.ReadLine();
                        Console.Clear();
                        goto case LogInMenuEnum.LogIn;
                    case LogInMenuEnum.Guest:
                        Console.WriteLine("You enter as a guest");
                        LogIn = true;
                        break;
                }
            }
            Console.ReadLine();
            Console.Clear();
            LogIn = false;
            return (User)user;
        }

        private void Registration()
        {
            var validatorLoginRegist = new ValidatorLoginRegist();
            var validatorPasswordRegist = new ValidatorPasswordRegist();
            var validatorName = new ValidatorName();

            Console.WriteLine("Create your Login (It should be begger than 4 letter)");
            Login = ReadString.FromConsole(validatorLoginRegist);

            Console.WriteLine("Create your Password (It should be begger than 6 letter)");
            Password = ReadString.FromConsole(validatorPasswordRegist);

            Console.WriteLine("Enter your name");
            Name = ReadString.FromConsole(validatorName);

        }

        private void TryLogIn()
        {
            var validatorLogIn = new ValidatorLoginLogIn();
            Console.WriteLine("Enter your Login or exit(if you don't wont LogIn)");
            Login = ReadString.FromConsole(validatorLogIn);
            if (Login == "exit") return;
            Console.Clear();

            Console.WriteLine("Enter password or exit(if you don't wont LogIn)");
            Password = ReadString.FromConsole();
            if (Password == "exit") return;
            int countAttemps = 1;
            while (Password != UserRepo.Get(Login).Password)
            {
                if (countAttemps == Try)
                {
                    Password = "exit";
                    Console.WriteLine("You use 3/3 attemps to enter.");
                    return;
                }
                Console.WriteLine("Not correct password. Enter password or if you foget password you can restore it. Type restore.");
                Password = ReadString.FromConsole();
                countAttemps++;
                if (Password == "restore")
                {
                    if (UserRepo.Get(Login).LogIn)
                    {
                        Console.WriteLine("Sorry, but this account is used now.");
                        Password = "exit";
                        return;
                    }
                    RestorePassword();
                    return;
                }
            }

            if (Password == UserRepo.Get(Login).Password)
            {
                if (UserRepo.Get(Login).LogIn == true)
                {
                    Console.WriteLine("Error. Another user use this account");
                }
                else LogIn = true;
            }
        }

        private void RestorePassword()
        {
            var validatorName = new ValidatorName();
            var validatorLogIn = new ValidatorLoginLogIn();
            var validatorPasswordRegist = new ValidatorPasswordRegist();

            Console.Clear();

            Console.WriteLine("Enter your Login");
            Login = ReadString.FromConsole(validatorLogIn);
            var user = UserRepo.Get(Login);

            Console.WriteLine("Enter Name, that you enter when you register");
            int count = 1;
            while (count <= Try)
            {
                var name = ReadString.FromConsole(validatorName);
                if (name == user.Name)
                {
                    Console.WriteLine("Enter new password");
                    Password = ReadString.FromConsole(validatorPasswordRegist);
                    user.Password = Password;
                    UserRepo.Save(user);
                    break;
                }
                else
                {
                    if (Try != count) Console.WriteLine($"Check correction of Name. You still have {Try - count} attempts.");
                    count++;
                }
            }

            Console.Clear();

        }
    }
}
