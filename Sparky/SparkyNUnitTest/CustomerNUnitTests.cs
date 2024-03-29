﻿using NUnit.Framework;
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
            customer.GreetAndCombineNames("Ben", "Spark");

            //Assert
            Assert.Multiple(() => {
                Assert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));

                Assert.That(customer.GreetMessage, Does.Contain(","));
                Assert.That(customer.GreetMessage, Does.Contain("Ben Spark"));
                Assert.That(customer.GreetMessage, Does.Contain("ben Spark").IgnoreCase);

                Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
                Assert.That(customer.GreetMessage, Does.EndWith("Spark"));

                //Macthiing with regular expression
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));

            });
           
           
        }
        
        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //act
            //Assert
            Assert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(String.IsNullOrEmpty(customer.GreetMessage));

        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => {
                customer.GreetAndCombineNames("", "Spark");
            });
           
            Assert.AreEqual("First Name is Empty.", exceptionDetails.Message);
          
            Assert.That(()=>customer.GreetAndCombineNames("", "Spark"), 
                Throws.ArgumentException.With.Message.EqualTo("First Name is Empty."));

            Assert.Throws<ArgumentException>(() => {
                customer.GreetAndCombineNames("", "Spark");
            });
            Assert.That(() => customer.GreetAndCombineNames("", "Spark"),
               Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        { 
            customer.OrderTotal = 10;
            var result =customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }
        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
