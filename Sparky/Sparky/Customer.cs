using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public string GreetMessage { get; set; }
        public int Discount = 15;
        public string CombineNames(string firstName, string lastName)
        { 
            GreetMessage = $"Hello, {firstName} {lastName}";
            Discount = 20 ;
            return GreetMessage;
        }
    }
}
