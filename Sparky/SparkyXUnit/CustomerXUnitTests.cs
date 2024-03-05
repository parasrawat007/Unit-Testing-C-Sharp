﻿using Sparky;
using Xunit;
using Xunit.Sdk;

namespace SparkyNUnitTest
{
    public class CustomerXUnitTests
    {
        private Customer customer;

        public  CustomerXUnitTests()
        {
            //Arrange 
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {

            //Act
            customer.GreetAndCombineNames("Ben", "Spark");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.Equal( "Hello, Ben Spark", customer.GreetMessage);

                Assert.Contains(",",customer.GreetMessage);
                Assert.Contains("Ben Spark",customer.GreetMessage);
                Assert.Contains("ben Spark",customer.GreetMessage,StringComparison.CurrentCultureIgnoreCase);

                Assert.StartsWith("Hello,",customer.GreetMessage);
                Assert.EndsWith("Spark", customer.GreetMessage);

                //Macthiing with regular expression
                Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+",customer.GreetMessage);

            });


        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //act
            //Assert
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.InRange(result,10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(String.IsNullOrEmpty(customer.GreetMessage));

        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() =>
            {
                customer.GreetAndCombineNames("", "Spark");
            });

            Assert.Equal("First Name is Empty.", exceptionDetails.Message);
            Assert.Throws<ArgumentException>(() => {
                customer.GreetAndCombineNames("", "Spark");
            });
        }

   

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }
        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
