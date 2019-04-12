using Dal.Repositorys;
using NumbersGame.Validators;
using NUnit.Framework;
using Dal.Models;
using NumberGame.Validators;

namespace Validators
{
    public class ValidatorMinTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(10, 1)]
        [TestCase(100, -90)]
        [TestCase(-22, -100)]
        public void NumberShouldBeBigger_True(int number, int min)
        {
            //var
            ValidatorMin validatorMin = new ValidatorMin(min);

            //act
            var actualResult = validatorMin.Validate(number);

            //assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        [TestCase(10, 20)]
        [TestCase(100, 200)]
        [TestCase(-22, 0)]
        public void NumberShouldBeBigger_False(int number, int min)
        {
            //var
            ValidatorMin validatorMin = new ValidatorMin(min);

            //act
            var actualResult = validatorMin.Validate(number);

            //assert
            Assert.IsFalse(actualResult);
        }
    }
}