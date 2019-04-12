using NUnit.Framework;
using Newtonsoft.Json;
using Dal.Helpers;
using Dal.Models;
using Moq;
using Dal.Repositorys;
using System;
using System.IO;

namespace Repositorys
{
    public class BaseRepository
    {
        private string appPath = Environment.CurrentDirectory;
        private string FolderName = "Users";
        private string RepositoryPath ;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Somebody")]
        [TestCase("Adsds")]
        [TestCase("Sergey")]
        [TestCase("Musa")]
        [TestCase("Kirito")]
        public void GetPath(string login)
        {
            //var 
            var UserRepo = new UsersRepository();
            RepositoryPath = Path.Combine(appPath, FolderName);
            string PathExpected = Path.Combine(RepositoryPath, $"{login}.json"); 
            
            //act
            string actualRepositoryPath = UserRepo.GetPath(login);

            //assert
            Assert.AreEqual(PathExpected, actualRepositoryPath);
        }
    }
}