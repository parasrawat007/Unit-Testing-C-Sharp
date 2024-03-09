using Bongo.Models.ModelValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bongo.Models
{
    public class DateInFutureAttributeTest
    {
        DateInFutureAttribute dateInFutureAttribute;  
        public DateInFutureAttributeTest()
        {
                dateInFutureAttribute = new DateInFutureAttribute(()=>DateTime.Now);
        }

        [Fact]
        public void DateValidator_AnyDate_ReturnErrorMessage() 
        { 
            Assert.Equal("Date must be in the future",dateInFutureAttribute.ErrorMessage);
        }

        [Theory]
        [InlineData(100,true)]
        [InlineData(-100,false)]
        [InlineData(0,false)]
        public void DateValidator_InputExpectedDateRange_DateValidity(int addTime,bool expectedResult)
        {
            var result = dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(addTime));
            Assert.Equal(expectedResult, result);
        }
    }
}
