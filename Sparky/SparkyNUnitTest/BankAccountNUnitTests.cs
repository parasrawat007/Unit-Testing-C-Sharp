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
        private BankAccount bankAccount;
        
        [SetUp]
        public void Setup()
        {
            bankAccount = new(new LogBook());
        }

        [Test]
        public void BankDeposit_Add100_ReturnsTrue() 
        {
            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }
    }
}
