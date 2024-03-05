using Sparky;
using Xunit;


namespace SparkyNUnitTest
{

    public class FiboXUnitTests
    {
        private Fibo fibo;
        public  FiboXUnitTests()
        {
            fibo = new Fibo();
        }

        [Fact]
        public void FiboChecker_Input1_ReturnFiboSeries()
        {
            List<int> expectedRange = new() { 0 };
            fibo.Range = 1;
            var result = fibo.GetFiboSeries();
            Assert.NotEmpty(result);
            Assert.Equal(expectedRange.OrderBy(x=>x), result);
            //Assert.Equal(expectedRange, result);
            Assert.True(expectedRange.SequenceEqual(result));
        }

        [Fact]
        public void FiboChecker_Input6_ReturnFiboSeries()
        {
            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };
            fibo.Range = 6;
            var result = fibo.GetFiboSeries();
            Assert.Contains(3,result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4,result);
            Assert.Equal(expectedRange, result);
        }

    }
}
