using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyMSTest
{
    [TestClass]
    public class CalculatorMSTest
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        { 
            //Arrange --> Initialization
            Calculator calc = new Calculator();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Accert
            Assert.AreEqual(30, result);
        }
    }
}
