using Dal.Helpers;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositorys
{
    public class UsersRepository: BaseRepository<User>
    {
        private static string folderName = "Users";

        public UsersRepository():base(folderName)
        {
        
        } 
    }
}
