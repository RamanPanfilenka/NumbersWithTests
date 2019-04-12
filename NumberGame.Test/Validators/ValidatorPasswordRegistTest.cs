using Dal.Repositorys;
using NumbersGame.Validators;
using NUnit.Framework;
using Dal.Models;
using NumberGame.Validators;

namespace Validators
{
    public class ValidatorPasswordRegistTest
    {
        ValidatorPasswordRegist validatorPasswordRegist = new ValidatorPasswordRegist(); 

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("1234567")]
        [TestCase("HardPassword")]
        [TestCase("iwatchingyou")]
        [TestCase("somepass")]
        [TestCase("milisipipo")]
        [TestCase("SweetTotoro")]
        public void IsPossiblePassword_True(string password)
        {
            //act
            var actualResult = validatorPasswordRegist.Validate(password);

            //assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        [TestCase("dsadsa sad")]
        [TestCase("dadadafsfagregsjdtyjsrgaegsjrsjrwhgwgsrhdyjtydjrdghsegsgsjsjdfhtsh")]
        [TestCase("dsad?")]
        [TestCase("gdgdf|")]
        [TestCase("sdd sd sad")]
        [TestCase("???")]
        [TestCase(" ")]
        [TestCase("")]
        [TestCase("restore")]
        public void IsPossiblePassword_False(string password)
        {

            //act
            var actualResult = validatorPasswordRegist.Validate(password);

            //assert
            Assert.IsFalse(actualResult);
        }
    }
}