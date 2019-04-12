using Dal.Repositorys;
using NumbersGame.Validators;
using NUnit.Framework;
using Dal.Models;
using NumberGame.Validators;

namespace Validators
{
    public class ValidatorNameTest
    {
        ValidatorName validatorName = new ValidatorName(); 

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Some")]
        [TestCase("Stive")]
        [TestCase("Larisa")]
        [TestCase("John")]
        [TestCase("Zeriskulis")]
        [TestCase("UriSvuni")]
        public void IsPossibleName_True(string name)
        {
            //act
            var actualResult = validatorName.Validate(name);

            //assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        [TestCase("....")]
        [TestCase("dadadafsfagregsjdtyjsrgaegsjrsjrwhgwgsrhdyjtydjrdghsegsgsjsjdfhtsh")]
        [TestCase("adadad242342")]
        [TestCase("dad a d asd")]
        [TestCase("??")]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("/dsd")]
        public void IsPossibleName_False(string name)
        {

            //act
            var actualResult = validatorName.Validate(name);

            //assert
            Assert.IsFalse(actualResult);
        }
    }
}