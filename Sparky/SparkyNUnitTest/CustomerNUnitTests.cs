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
        private Customer customer;

       
        [SetUp]
        public void Steup()
        {
            //Arrange 
            customer = new Customer();
        }
        
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            
            //Act
            customer.CombineNames("Ben", "Spark");

            //Assert
            Assert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");
            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));

            Assert.That(customer.GreetMessage, Does.Contain(","));
            Assert.That(customer.GreetMessage, Does.Contain("Ben Spark"));
            Assert.That(customer.GreetMessage, Does.Contain("ben Spark").IgnoreCase);

            Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
            Assert.That(customer.GreetMessage, Does.EndWith("Spark"));

            //Macthiing with regular expression
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }
        
        [Test]
        public void GreeTMessage_NotGreeted_ReturnsNull()
        {
            //act
            //Assert
            Assert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 20));
        }
    }
}
