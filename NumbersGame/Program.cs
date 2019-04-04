using Dal.Models;
using Dal.Repositorys;
using NumberGame.Validators;
using NumbersGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var UsersRepo = new UsersRepository();
            var LogIn = new LogInMenu();

            var Guest = new User("Guest");
            UsersRepo.Save(Guest);

            Console.WriteLine("Player 1");
            var player1 = LogIn.GetPlayer();
            Console.WriteLine("Player 2");
            var player2 = LogIn.GetPlayer();

            var Game = new GameNumber(player1, player2);

            Game.StartGame();
        }

       
    }
}
