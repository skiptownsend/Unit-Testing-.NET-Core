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
        private BankAccount bankAccount;
        [SetUp]
        //public void Setup()
        //{
        //    bankAccount = new(new LogBook()); //Because we are now testing two classes, BankAccount & LogBook, this is no longer a Unit Test, but an Integration Test
        //}
        public void Setup()
        {
            var logMock = new Mock<ILogBook>();
            bankAccount = new(logMock.Object);
        }

        //Unit Test Using LogFaker
        [Test]
        public void BankDepositLogFaker_Add100_ReturnTrue()
        {
            BankAccount bankAccountFaker = new(new LogFaker()); //This line would typically go in Setup()
            var result = bankAccountFaker.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccountFaker.GetBalance, Is.EqualTo(100));
        }

        //Unit Test Using Moq
        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var result = bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }
    }
}
