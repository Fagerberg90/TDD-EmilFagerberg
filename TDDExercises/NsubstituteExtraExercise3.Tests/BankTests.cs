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
        private IAuditLogger iAuditLogger;
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

            Assert.AreEqual("Emil", result.Name);
            Assert.AreEqual(0, result.Balance);
            Assert.AreEqual("1", result.Number);
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
            iAuditLogger.Received().AddMessage(Arg.Is<string>(a => a.Contains(acc.Name) && a.Contains(acc.Number)));
        }

        [Test]
        public void WhenCreatingAnValidAccount_OneMessageAreWrittenToTheAuditLog()
        {

            sut.CreateAccount(acc);
            sut.GetAuditLog();

            iAuditLogger.Received(1).AddMessage(Arg.Any<string>());

        }

      
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        //[Test]
        //public void WhenCreatingAnInvalidAccount_TwoMessagesAreWrittenToTheAuditLog()
        //{


        //}

        //[Test]
        //public void WhenCreatingAnInvalidAccount_AWarn12AndErro45MessageIsWrittenToAuditLog()
        //{


        //}

        //[Test]
        //public void VerifyThat_GetAuditLog_GetsTheLogFromTheAuditLogger()
        //{


        //}





    }
}
