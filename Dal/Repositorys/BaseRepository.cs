using Dal.Helpers;
using Dal.IRepository;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositorys
{
    public abstract class BaseRepository<T>: IBaseRepository<T>  where T : BaseModel
    {
        private string RepositoryPath;  
        private string appPath = Environment.CurrentDirectory;
        private string FolderName;
        public BaseRepository(string folderName)
        {
            FolderName = folderName;
            RepositoryPath = Path.Combine(appPath, folderName);
            if (!Directory.Exists(RepositoryPath))
            {
                Directory.CreateDirectory(RepositoryPath);
            }
        }

        public void Save(T model)
        {
            var json = JsonHelper.Serializer(model);
            var path = GetPath(model.Login);
            using (var stream = new StreamWriter(path))
            {
                stream.Write(json);
            }
        }

        public T Get(string Login)
        {
            var path = GetPath(Login);
            if (!File.Exists(path))
            {
                return null;
            }
            using (var stream = new StreamReader(path))
            {
                var json = stream.ReadToEnd();
                var model = JsonHelper.DeSerializer<T>(json);
                return model;
            }
        }

        public string GetPath(string Login)
        {
            return Path.Combine(RepositoryPath, $"{Login}.json");
        }
    }
}
