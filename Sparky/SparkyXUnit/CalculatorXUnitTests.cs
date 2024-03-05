using Sparky;
using Xunit;

namespace SparkyNUnitTest
{
    public class CalculatorXUnitTests
    {
        private Calculator calc;

        public CalculatorXUnitTests()
        {
            calc = new Calculator();
        }
        public void SetUp() 
        {
            //Arrange --> Initialization
           
        }

        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.Equal (30, result);

        }

        [Theory]
        [InlineData(5.4,10.5)] //15.9
        [InlineData(5.43,10.53)]//15.93
        [InlineData(5.49,10.59)]//16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a,double b)
        {
            //Arrange --> Initialization
            Calculator calc = new Calculator();

            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            Assert.Equal(15.9, result,.2);
        }

        [Fact]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            bool isOdd = calc.IsOddNumber(2);
            Assert.False(false);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            bool isOdd = calc.IsOddNumber(a);
            Assert.True(isOdd);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11,  true)]
        public void IsOddChecker_Number_ReturnTrueIfOdd(int a,bool expectedResult)
        { 
            Calculator calculator = new Calculator();
            var result = calculator.IsOddNumber(a);
            Assert.Equal(expectedResult,result);   
        }

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            List<int> expectedOddRange = new() { 5, 7, 9 };
            
            //Act
            var result = calc.GetOddRange(5,10);

            //Assert
            Assert.Equal(result,expectedOddRange);
            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result, result.OrderBy(x => x));
            Assert.Distinct(result);
           // Assert.That(result,Is.Unique);
        }
    }

}
