using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Stats : BaseModel
    {
        public int TotalGames { get; set; } = 0;
        public int WinRate { get; set; } = 0;
        public int Wins { get; set; } = 0;
        public int Lose { get; set; } = 0;

        public Stats(string login)
        {
            Login = login;
        }

        public void CalcStats(bool Win)
        {
            TotalGames++;
            if (Win)
            {
                Wins++;
            }
            else
            {
                Lose++;
            }
            double temp = (double)Wins / TotalGames;
            WinRate = (int)(temp*100);
        }
    }
}
