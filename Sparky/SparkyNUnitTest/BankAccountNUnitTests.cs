using Moq;
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
          
        } 

        //[Test]
        //public void BankDepositlogFakker_Add100_ReturnsTrue() 
        //{
        //    BankAccount bankAccount = new(new LogFakker());
        //    var result = bankAccount.Deposit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        //}

        [Test]
        public void BankDeposit_Add100_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);

            var result = bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }
        
        [Test]
        [TestCase(200,100)]
        [TestCase(200,150)]
        public void BankWitdrawn_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        { 
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<String>())).Returns(true);
            logMock.Setup(x=>x.LogBalanceAfterWithdrawl(It.Is<int>(i=>i>0))).Returns(true);

            BankAccount account = new(logMock.Object);
            account.Deposit(balance);  
            var result= account.Withdraw(withdraw);
            Assert.IsTrue(result);  

        }

        [Test]
        [TestCase(200, 300)]
        public void BankWitdrawn_Withdraw300With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            //logMock.Setup(x => x.LogBalanceAfterWithdrawl(It.Is<int>(i => i < 0))).Returns(false);
            logMock.Setup(x => x.LogBalanceAfterWithdrawl(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);
            BankAccount account = new(logMock.Object);
            account.Deposit(balance);
            var result = account.Withdraw(withdraw);
            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Hello";
            logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<String>())).Returns((string str) => str.ToLower());
            Assert.That(logMock.Object.MessageWithReturnStr("HELLO"),Is.EqualTo(desiredOutput.ToLower()));
        }
        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Hello";
            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<String>(),out desiredOutput)).Returns(true);
            var result = "";
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben",out result));
            Assert.That(result, Is.EqualTo(desiredOutput));
        }
    }
}
