
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
        [TestCase(5.4,10.5)] //15.9
        [TestCase(5.43,10.53)]//15.93
        [TestCase(5.49,10.59)]//16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a,double b)
        {
            //Arrange --> Initialization
            Calculator calc = new Calculator();

            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            Assert.AreEqual(15.9, result,.2);


        }
        [Test]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            Calculator calc = new Calculator();
            bool isOdd = calc.IsOddNumber(2);
            Assert.That(isOdd, Is.EqualTo(false));
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            Calculator calc = new Calculator();
            bool isOdd = calc.IsOddNumber(a);
            Assert.IsTrue(isOdd);
        }
        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_Number_ReturnTrueIfOdd(int a)
        { 
            Calculator calculator = new Calculator();
            return calculator.IsOddNumber(a);   
        }
    }
}
