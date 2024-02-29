namespace Sparky
{
    public class Calculator
    {
        public int AddNumbers(int x, int y)
        { 
            return x + y; 
        }
        public double AddNumbersDouble(double x, double y)
        {
            return x + y;
        }
        public bool IsOddNumber(int x)
        { 
            return x % 2 != 0;
        }
    }
}
