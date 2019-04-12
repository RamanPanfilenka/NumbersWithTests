using Dal.Models;
using Dal.Repositorys;
using NumberGame.Validators;
using NumbersGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NumberGame.Game
{
    public class GameNumber
    {
        public bool win = false;
        private int Min;
        private int Max;
        private int attempCount;
        private int attemp = 0;
        private int player1Number;
        private User Player1;
        private User Player2;

        public GameNumber(User plaeyr1, User plaeyr2)
        {
            Player1 = plaeyr1;
            Player2 = plaeyr2;
        }

        public void StartGame()
        {

            FirstPlayerStep();

            SecondPlayerStep();

            EndGame();


            Console.ReadLine();
        }

        private void FirstPlayerStep()
        {
            Console.WriteLine($"{Player1.Name} Enter the Min board");
            Min = ReadInteger.FromConsole();

            var validatorMin = new ValidatorMin(Min);

            Console.WriteLine($"{Player1.Name} Enter the Max board");
            Max = ReadInteger.FromConsole(validatorMin);

            var validatorMinMax = new ValidatorMinMax(Min, Max);

            Console.WriteLine($"{Player1.Name} Enter the Number");
            player1Number = ReadInteger.FromConsole(validatorMinMax);

            attempCount = AttempCalculator(Min, Max);
        }

        private void SecondPlayerStep()
        {
            var validatorMinMax = new ValidatorMinMax(Min, Max);


            Console.Clear();
            Console.WriteLine($"Wait {Player2.Name}");
            Console.ReadLine();

            int player2Number;
            do
            {
                Console.WriteLine($"Try to guess the number. This number located between {Min} and {Max}. It's your {++attemp}/{attempCount} attemp");
                player2Number = ReadInteger.FromConsole(validatorMinMax);
                if (player2Number > player1Number)
                {
                    Console.WriteLine($"{player2Number} is biger than conceived");
                }

                if (player2Number < player1Number)
                {
                    Console.WriteLine($"{player2Number} is less than conceived");
                }

                if (player1Number == player2Number)
                    win = true;
            } while ((player1Number != player2Number) && (attemp < attempCount));
        }

        public void EndGame()
        {
            if (win)
            {
                Console.WriteLine($"{Player2.Name} is Win");
                Console.WriteLine($"{Player2.Name}, now your Score = {Player2.Score} + 3 = {Player2.Score + 3}");
                int NewScore;

                if (Player1.Score <= 2)
                    NewScore = 0;
                else
                    NewScore = Player1.Score - 2;

                Console.WriteLine($"{Player1.Name}, now your Score = {Player1.Score} - 2 = {NewScore}");
                Player2.Score += 3;

                if (Player1.Score >= 2)
                    Player1.Score -= 2;
                else
                    Player1.Score = 0;

                if(Player2.Stats != null) Player2.Stats.CalcStats(true);
                if(Player1.Stats != null) Player1.Stats.CalcStats(false);
            }
            else
            { 
                Console.WriteLine($"{Player1.Name} is Win");
                Console.WriteLine($"{Player1.Name}, now your Score = {Player1.Score} + 3 = {Player1.Score + 3}");
                int NewScore;
                if (Player2.Score <= 2)
                {
                    NewScore = 0;
                }
                else {
                    NewScore = Player2.Score - 2;
                }
                Console.WriteLine($"{Player2.Name}, now your Score = {Player2.Score} - 2 = {NewScore}");
                Player1.Score += 3;
                if (Player2.Score >= 2)
                    Player2.Score -= 2;
                else {
                    Player2.Score = 0;
                }
                if (Player1.Stats != null) Player2.Stats.CalcStats(false);
                if (Player2.Stats != null) Player1.Stats.CalcStats(true);
            }
            if (Player1.Stats != null && Player2.Stats != null) SaveAll();
            

        }

        private void SaveAll()
        {
            var UserRepo = new UsersRepository();
            var StatsRepo = new StatsRepository();

            Player1.LogIn = false;
            Player2.LogIn = false;

            UserRepo.Save(Player1);
            UserRepo.Save(Player2);

            StatsRepo.Save(Player1.Stats);
            StatsRepo.Save(Player2.Stats);
        }

        public User GetPlayer1()
        {
            return Player1;
        }

        public User GetPlayer2()
        {
            return Player2;
        }
        public int AttempCalculator(int Min, int Max)
        {
            int length = Max - Min + 1;
            int power = 1;
            int value = 2;
            while (value < length)
            {
                power++;
                value *= 2;
                if (power == 100)
                {
                    break;
                }
            }
            return power;
        }
    }
}
