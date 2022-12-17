using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        [SetUp]
        //public void Setup()
        //{
        //    bankAccount = new(new LogBook()); //Because we are now testing two classes, BankAccount & LogBook, this is no longer a Unit Test, but an Integration Test
        //}
        public void Setup()
        {
            
            
        }

        //Unit Test Using LogFaker
        //[Test]
        //public void BankDepositLogFaker_Add100_ReturnTrue()
        //{
        //    BankAccount bankAccountFaker = new(new LogFaker()); //This line would typically go in Setup()
        //    var result = bankAccountFaker.Deposit(100);

        //    Assert.IsTrue(result);
        //    Assert.That(bankAccountFaker.GetBalance, Is.EqualTo(100));
        //}

        //Unit Test Using Moq
        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.Message(""));

            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200,100)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdrawal)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdrawal);

            Assert.IsTrue(result);

        }

        [Test]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse()
        {
            var logMock = new Mock<ILogBook>();
            //logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(200);
            var result = bankAccount.Withdraw(300);

            Assert.IsFalse(result);

        }
    }
}
