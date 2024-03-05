using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ICustomer
    {
        string GreetMessage { get; set; }
        int Discount { get; set; }
        int OrderTotal { get; set; }
        bool IsPlatinum { get; set; }

        string GreetAndCombineNames(string firstName, string lastName);
        CustomerType GetCustomerDetails();
    }

    public class Customer:ICustomer
    {
        public string GreetMessage { get; set; }
        public int Discount { get; set; }
        public int OrderTotal { get; set; }
        public bool IsPlatinum { get; set; }

        public Customer()
        {
            IsPlatinum = false;
            Discount = 10;
        }

        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (String.IsNullOrEmpty(firstName))
                throw new ArgumentException("First Name is Empty.");

            GreetMessage = $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetMessage;
        }
        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
                return new BasicCustomer();
            return new PlatinumCustomer();
        }
    }
    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PlatinumCustomer : CustomerType { }
}
