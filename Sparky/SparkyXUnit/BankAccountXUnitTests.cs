//using Moq;
//using NUnit.Framework;
//using Sparky;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SparkyNUnitTest
//{
//    [TestFixture]
//    public class BankAccountXUnitTests
//    {
//        private BankAccount account;
        
//        [SetUp]
//        public void Setup()
//        {
          
//        } 

//        //[Test]
//        //public void BankDepositlogFakker_Add100_ReturnsTrue() 
//        //{
//        //    BankAccount bankAccount = new(new LogFakker());
//        //    var result = bankAccount.Deposit(100);
//        //    Assert.IsTrue(result);
//        //    Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
//        //}

//        [Test]
//        public void BankDeposit_Add100_ReturnsTrue()
//        {
//            var logMock = new Mock<ILogBook>();
//            BankAccount bankAccount = new(logMock.Object);

//            var result = bankAccount.Deposit(100);

//            Assert.IsTrue(result);
//            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
//        }
        
//        [Test]
//        [TestCase(200,100)]
//        [TestCase(200,150)]
//        public void BankWitdrawn_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
//        { 
//            var logMock = new Mock<ILogBook>();
//            logMock.Setup(x => x.LogToDb(It.IsAny<String>())).Returns(true);
//            logMock.Setup(x=>x.LogBalanceAfterWithdrawl(It.Is<int>(i=>i>0))).Returns(true);

//            BankAccount account = new(logMock.Object);
//            account.Deposit(balance);  
//            var result= account.Withdraw(withdraw);
//            Assert.IsTrue(result);  

//        }

//        [Test]
//        [TestCase(200, 300)]
//        public void BankWitdrawn_Withdraw300With200Balance_ReturnsTrue(int balance, int withdraw)
//        {
//            var logMock = new Mock<ILogBook>();
//            //logMock.Setup(x => x.LogBalanceAfterWithdrawl(It.Is<int>(i => i < 0))).Returns(false);
//            logMock.Setup(x => x.LogBalanceAfterWithdrawl(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);
//            BankAccount account = new(logMock.Object);
//            account.Deposit(balance);
//            var result = account.Withdraw(withdraw);
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public void BankLogDummy_LogMockString_ReturnTrue()
//        {
//            var logMock = new Mock<ILogBook>();
//            string desiredOutput = "Hello";
//            logMock.Setup(u => u.MessageWithReturnStr("Hi")).Returns((string str) => str.ToLower());
//            Assert.That(logMock.Object.MessageWithReturnStr("HELLO"),Is.EqualTo(desiredOutput.ToLower()));
//        }
//        [Test]
//        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
//        {
//            var logMock = new Mock<ILogBook>();
//            string desiredOutput = "Hello";
//            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<String>(),out desiredOutput)).Returns(true);
//            var result = "";
//            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben",out result));
//            Assert.That(result, Is.EqualTo(desiredOutput));
//        }
//        [Test]
//        public void BankLogDummy_LogRefChecker_ReturnTrue()
//        {
//            var logMock = new Mock<ILogBook>();

//            Customer customer = new Customer();
//            Customer customerNotUsed = new Customer();

//            logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);

//            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
//            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
//        }
//        [Test]
//        public void BankLogDummy_LogRefCheckerSetAndGetLogSeverityMock_MockTest()
//        {
//            var logMock = new Mock<ILogBook>();

//            logMock.SetupAllProperties(); //now it will work because order matters

//            logMock.Setup(u => u.LogSeverity).Returns(10);
//            logMock.Setup(u => u.LogType).Returns("Warning");
//            //logMock.Object.LogSeverity = 100; Doesnot work invalid but wouldnot give error

//            //logMock.SetupAllProperties(); This way it will work
//            //logMock.Object.LogSeverity = 100; will also give error for warning
//            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
//            Assert.That(logMock.Object.LogType, Is.EqualTo("Warning"));

//            //callbacks
//            string logTemp = "Hello, ";
//            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
//                .Returns(true)
//                .Callback((string str) => logTemp += str);
//            logMock.Object.LogToDb("Ben");
//            Assert.That(logTemp,Is.EqualTo("Hello, Ben"));

//            //callbacks
//            int counter = 5;
//            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
//                .Callback((string str) => counter++)
//                .Returns(true)
//                .Callback((string str) => counter++);
//            logMock.Object.LogToDb("Ben");
//            Assert.That(counter, Is.EqualTo(7));
//        }
//        [Test]
//        public void BankLogDummy_VerifyExample()
//        {
//            var logMock = new Mock<ILogBook>();
//            var bankAccount = new BankAccount(logMock.Object);
//            bankAccount.Deposit(100);
//            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));

//            //verification
//            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
//            logMock.Verify(u => u.Message( "Deposit Invoked"), Times.AtLeastOnce);
//            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);
//            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
//            logMock.VerifyGet(u => u.LogSeverity , Times.Once);

//        }
//    }
//}
