using Dal.Models;
using NUnit.Framework;
using Moq;
using NumberGame.Game;

namespace Game
{
    public class GameNumberTest
    {
        private GameNumber Game;
        private User Player1;
        private User Player2;

        [SetUp]
        public void Setup()
        {
            var player1 = new Mock<User>();
            var player2 = new Mock<User>();
            var GameNumber = new GameNumber(player1.Object, player2.Object);
            Game = GameNumber;
            Player1 = player1.Object;
            Player2 = player2.Object;
        }
        [Test]
        [TestCase(1,10, 4)]
        [TestCase(-3, 20, 5)]
        [TestCase(80, 230, 8)]
        public void AttempCalculator(int min, int max, int expected)
        {
            //act
            var actual = Game.AttempCalculator(min, max);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(3,3)]
        public void EndGame_AddScore_Player2Win(int ScorePlayer1, int ScorePlayer2)
        {
            //var
            Player1.Score = ScorePlayer1;
            Player2.Score = ScorePlayer2;
            Game.win = true;
            //act 
            
            Game.EndGame();

            //assert

            Assert.IsTrue((Game.GetPlayer2().Score - ScorePlayer2) == 3);
            Assert.IsTrue((ScorePlayer1  - Game.GetPlayer1().Score) <= 2 || (ScorePlayer1 - Game.GetPlayer1().Score) >= 0);
        }

        [Test]
        [TestCase(3, 3)]
        public void EndGame_AddScore_Player1Win(int ScorePlayer1, int ScorePlayer2)
        {
            //var
            Player1.Score = ScorePlayer1;
            Player2.Score = ScorePlayer2;
            //act 

            Game.EndGame();

            //assert

            Assert.IsTrue((Game.GetPlayer1().Score - ScorePlayer1) == 3);
            Assert.IsTrue((ScorePlayer2 - Game.GetPlayer2().Score) <= 2 || (ScorePlayer2 - Game.GetPlayer2().Score) >= 0);
        }
    }
}