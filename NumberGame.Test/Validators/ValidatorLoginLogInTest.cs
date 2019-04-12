using Dal.Repositorys;
using NumbersGame.Validators;
using NUnit.Framework;
using Dal.Models;
using Moq;
using Dal.IRepository;

namespace Validators
{
    public class ValidatorLoginLogInTest
    {
        ValidatorLoginLogIn validatorLoginLogIn = new ValidatorLoginLogIn();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Stive")]
        [TestCase("SomeBody")]
        [TestCase("Boby")]
        [TestCase("Anderey")]
        [TestCase("Sova")]
        [TestCase("ChaiTogether")]
        [TestCase("exit")]
        public void LoginIsExistAndCorret_OrItExit(string Login)
        {
            //var
            var UserRepo = new Mock<IUsersRepository>();
            var UserExpected = new User("", Login);
            //User is exist
            UserRepo.Setup(x => x.Get(Login)).Returns(UserExpected);

            //act
            var actualResult = validatorLoginLogIn.Validate(Login, UserRepo.Object);

            //assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        [TestCase("")]
        [TestCase("Stive")]
        [TestCase("SomeBody")]
        [TestCase("Boby")]
        [TestCase("Anderey")]
        [TestCase("Sova")]
        [TestCase("ChaiTogether")]
        public void LoginIsNotAndNotCorret(string Login)
        {
            //var
            var UserRepo = new Mock<IUsersRepository>();
            var UserExpected = new User("", Login);
            User NullUser = null;
            //User is exist
            UserRepo.Setup(x => x.Get(Login)).Returns(NullUser);

            //act
            var actualResult = validatorLoginLogIn.Validate(Login, UserRepo.Object);

            //assert
            Assert.IsFalse(actualResult);
        }
    }
}