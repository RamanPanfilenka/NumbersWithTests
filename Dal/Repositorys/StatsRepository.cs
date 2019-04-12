using Dal.IRepository;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositorys
{
    public class StatsRepository : BaseRepository<Stats>, IStatsRepository
    {
        private static string folderName = "Stats";

        public StatsRepository() : base(folderName)
        {

        }
    }
}
