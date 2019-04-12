using NumbersGame.Validators;
using NUnit.Framework;

namespace Validators
{
    public class ValidatorEnterUserTest
    {
        ValidatorEnterUser validatorEnterUser = new ValidatorEnterUser();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ChooseOfUser_CorrectAnswers(int enterOfUser)
        {
            //act
            var actualResult = validatorEnterUser.Validate(enterOfUser);

            //assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        [TestCase(100)]
        [TestCase(-208)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(21456)]
        public void ChooseOfUser_NotCorrectAnswers(int enterOfUser)
        {
            //act
            var actualResult = validatorEnterUser.Validate(enterOfUser);

            //assert
            Assert.IsFalse(actualResult);
        }
    }
}