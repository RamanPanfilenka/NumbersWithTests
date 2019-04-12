using NUnit.Framework;
using Newtonsoft.Json;
using Dal.Helpers;
using Dal.Models;
using Moq;

namespace Tests
{
    public class Models
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, 3)]
        [TestCase(15, 29)]
        [TestCase(30, 3)]
        [TestCase(4, 15)]
        [TestCase(12, 3)]
        [TestCase(7, 8)]
        public void CalcStats_Win(int Wins, int Lose)
        {

            //var
            bool win = true;
            var Stat = new Stats("");
            var OldStat = new Stats("");
            Stat.Wins = Wins;
            Stat.Lose = Lose;
            OldStat.Wins = Wins;
            OldStat.Lose = Lose;
            //act
            Stat.CalcStats(win);

            //assert
            Assert.IsTrue((Stat.Wins - OldStat.Wins) == 1);
            Assert.IsTrue((Stat.Lose == OldStat.Lose));
            Assert.IsTrue(Stat.TotalGames > OldStat.TotalGames);
        }

        [Test]
        [TestCase(1,3)]
        [TestCase(15, 29)]
        [TestCase(30, 3)]
        [TestCase(4, 15)]
        [TestCase(12, 3)]
        [TestCase(7, 8)]
        public void CalcStats_Lose(int Wins, int Lose)
        {
            //var
            bool win = false;
            var Stat = new Stats("");
            var OldStat = new Stats("");
            Stat.Wins = Wins;
            Stat.Lose = Lose;
            OldStat.Wins = Wins;
            OldStat.Lose = Lose;
            //act
            Stat.CalcStats(win);

            //assert
            Assert.IsTrue((Stat.Lose - OldStat.Lose) == 1);
            Assert.IsTrue((Stat.Wins == OldStat.Wins));
            Assert.IsTrue(Stat.TotalGames > OldStat.TotalGames);
        }

    }
}