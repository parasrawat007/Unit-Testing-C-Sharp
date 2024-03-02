namespace Sparky
{
    public class Calculator
    {
        public List<int> NumberRange= new();
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
        public List<int> GetOddRange(int min, int max)
        {
            NumberRange.Clear();
            for (int i = min; i <= max; i++) 
            { 
                if(i%2!=0)
                    NumberRange.Add(i);
            }
            return NumberRange;
        } 
    }
}
