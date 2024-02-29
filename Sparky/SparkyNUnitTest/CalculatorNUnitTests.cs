
using NUnit.Framework;
using Sparky;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange --> Initialization
            Calculator calc = new Calculator();

            //Act
            int result = calc.AddNumbers(10, 20);
           
            //Assert
            Assert.AreEqual(30, result);
           
           
        }
        [Test]
        public void IsOddChecker_InputEvenNumber_ReturnFalse() 
        { 
            Calculator calc = new Calculator();
            bool isOdd = calc.IsOddNumber(2);
            Assert.That(isOdd,Is.EqualTo(false));
        }

        [Test]
        public void IsOddChecker_InputOddNumber_ReturnTrue()
        {
            Calculator calc = new Calculator();
            bool isOdd = calc.IsOddNumber(3);
            Assert.IsTrue(isOdd);
        }
    }
}
