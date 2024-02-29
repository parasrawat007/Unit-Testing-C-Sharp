using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            var customer = new Customer();
            //Act
            var fullName=customer.CombineNames("Ben", "Spark");
            //Assert
            Assert.That(fullName, Is.EqualTo("Hello, Ben Spark"));
        }

    }
}
