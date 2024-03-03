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
    public class BankAccountNUnitTests
    {
        private BankAccount account;
        
        [SetUp]
        public void Setup()
        {
            account = new(new LogFakker());
        } 

        [Test]
        public void BankDeposit_Add100_ReturnsTrue() 
        {
           
            var result = account.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(account.GetBalance(), Is.EqualTo(100));
        }
    }
}
