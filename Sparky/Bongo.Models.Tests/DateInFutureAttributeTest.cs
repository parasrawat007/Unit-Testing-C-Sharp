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
        public void DateValidator_InputExpectedDateRange_DateValidity()
        {
            var result = dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(100));
            Assert.True(result); 
        }
    }
}
