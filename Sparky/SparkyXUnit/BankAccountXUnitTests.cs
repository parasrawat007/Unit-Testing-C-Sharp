using Moq;
using Sparky;
using Xunit;

namespace SparkyNUnitTest
{
    public class BankAccountXUnitTests
    {
        private BankAccount account;

        public BankAccountXUnitTests()
        {

        }

        //[Fact]
        //public void BankDepositlogFakker_Add100_ReturnsTrue()
        //{
        //    BankAccount bankAccount = new(new LogFakker());
        //    var result = bankAccount.Deposit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        //}

        public void BankDeposit_Add100_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);

            var result = bankAccount.Deposit(100);

            Assert.True(result);
            Assert.Equal(100, bankAccount.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void BankWitdrawn_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<String>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdrawl(It.Is<int>(i => i > 0))).Returns(true);

            BankAccount account = new(logMock.Object);
            account.Deposit(balance);
            var result = account.Withdraw(withdraw);
            Assert.True(result);

        }

        [Theory]
        [InlineData(200, 300)]
        public void BankWitdrawn_Withdraw300With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            //logMock.Setup(x => x.LogBalanceAfterWithdrawl(It.Is<int>(i => i < 0))).Returns(false);
            logMock.Setup(x => x.LogBalanceAfterWithdrawl(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);
            BankAccount account = new(logMock.Object);
            account.Deposit(balance);
            var result = account.Withdraw(withdraw);
            Assert.False(result);
        }

        [Fact]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Hello";
            logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<String>())).Returns((string str) => str.ToLower());
            Assert.Equal(desiredOutput.ToLower(),logMock.Object.MessageWithReturnStr("HELLO"));
        }

        [Fact]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Hello";
            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<String>(), out desiredOutput)).Returns(true);
            var result = "";
            Assert.True(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.Equal(desiredOutput,result);
        }
        [Fact]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();

            Customer customer = new Customer();
            Customer customerNotUsed = new Customer();

            logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);

            Assert.True(logMock.Object.LogWithRefObj(ref customer));
            Assert.False(logMock.Object.LogWithRefObj(ref customerNotUsed));
        }
        [Fact]
        public void BankLogDummy_LogRefCheckerSetAndGetLogSeverityMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();

            logMock.SetupAllProperties(); //now it will work because order matters

            logMock.Setup(u => u.LogSeverity).Returns(10);
            logMock.Setup(u => u.LogType).Returns("Warning");
            //logMock.Object.LogSeverity = 100; Doesnot work invalid but wouldnot give error

            //logMock.SetupAllProperties(); This way it will work
            //logMock.Object.LogSeverity = 100; will also give error for warning
            Assert.Equal(10, logMock.Object.LogSeverity);
            Assert.Equal("Warning", logMock.Object.LogType);

            //callbacks
            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                .Returns(true)
                .Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("Ben");
            Assert.Equal("Hello, Ben", logTemp);

            //callbacks
            int counter = 5;
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                .Callback((string str) => counter++)
                .Returns(true)
                .Callback((string str) => counter++);
            logMock.Object.LogToDb("Ben");
            Assert.Equal(7, counter);
        }
        [Fact]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            var bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(100);
            Assert.Equal(100, bankAccount.GetBalance());

            //verification
            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Deposit Invoked"), Times.AtLeastOnce);
            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(u => u.LogSeverity, Times.Once);

        }
    }
}
