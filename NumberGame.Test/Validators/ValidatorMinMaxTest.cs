using Dal.Repositorys;
using NumbersGame.Validators;
using NUnit.Framework;
using Dal.Models;
using NumberGame.Validators;

namespace Validators
{
    public class ValidatorMinMaxTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(10, 1, 20)]
        [TestCase(100, -90, 200)]
        [TestCase(-22, -100, 0)]
        public void NumberShouldBeBiggerMinAndLessMax_True(int number, int min, int max)
        {
            //var
            var validatorMinMax = new ValidatorMinMax(min, max);

            //act
            var actualResult = validatorMinMax.Validate(number);

            //assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        [TestCase(10, 20, 30)]
        [TestCase(100, 90, 95)]
        [TestCase(-22, 0, -40)]
        public void NumberShouldBeBiggerMinAndLessMax_False(int number, int min, int max)
        {
            //var
            var validatorMinMax = new ValidatorMinMax(min, max);

            //act
            var actualResult = validatorMinMax.Validate(number);

            //assert
            Assert.IsFalse(actualResult);
        }
    }
}