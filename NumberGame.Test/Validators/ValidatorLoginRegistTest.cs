using Dal.Repositorys;
using NumbersGame.Validators;
using NUnit.Framework;
using Dal.Models;
using Moq;
using Dal.IRepository;

namespace Validators
{
    public class ValidatorLoginRegistTest
    {
        ValidatorLoginRegist validatorLoginRegist = new ValidatorLoginRegist();

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
        public void LoginIsCorret_And_Free(string Login)
        {
            //var
            var UserRepo = new Mock<IUsersRepository>();
            var UserExpected = new User("", Login);
            User NullUser = null;
            //User is not exit
            UserRepo.Setup(x => x.Get(Login)).Returns(NullUser);

            //act
            var actualResult = validatorLoginRegist.Validate(Login, UserRepo.Object);

            //assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("SomeBody")]
        [TestCase("Boby?")]
        [TestCase("Anderey||")]
        [TestCase("So va")]
        [TestCase("ChaiTogether")]
        [TestCase("An")]
        [TestCase("Sovasdsadasfsadasdafsdafsdfmfdsf")]
        [TestCase("ChaiTogether")]
        public void LoginIsNotCorret_OrUsed(string Login)
        {
            //var
            var UserRepo = new Mock<IUsersRepository>();
            var UserExpected = new User("", Login);
            //User is exist
            UserRepo.Setup(x => x.Get(Login)).Returns(new User("", Login));

            //act
            var actualResult = validatorLoginRegist.Validate(Login, UserRepo.Object);

            //assert
            Assert.IsFalse(actualResult);
        }
    }
}