using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using NsubstituteExtraExercise3;




namespace NsubstituteExtraExercise3.Tests
{
    [TestFixture]
    public class BankTests
    {
         Bank sut;
         IAuditLogger iAuditLogger;
        Account acc;

        [SetUp]
        public void SetUp()
        {
            iAuditLogger = Substitute.For<IAuditLogger>();
            sut = new Bank(iAuditLogger);
            acc = new Account { Name = "Emil", Balance = 0, Number = "1" };
        }

        [Test]
        public void CanCreateBankAccount()
        {
            sut.CreateAccount(acc);

            var result = sut.GetAccount("1");
            Assert.AreEqual(result.Name, "Emil");
            Assert.AreEqual(result.Balance, 0);
            Assert.AreEqual(result.Number, "1");
        }

        [Test]
        public void CanNotCreateDuplicateAccounts()
        {
            sut.CreateAccount(acc);
            Assert.Throws<DuplicateAccount>(() =>
            {
                sut.CreateAccount(acc);
            });
        }

        [Test]
        public void WhenCreatingAnAccount_AMessageIsWrittenToTheAuditLog()
        {
                          sut.CreateAccount(acc);
            iAuditLogger.Received().AddMessage(Arg.Is<string>(a=> a.Contains(acc.Name)&& a.Contains(acc.Number)));
        }








    }
}
