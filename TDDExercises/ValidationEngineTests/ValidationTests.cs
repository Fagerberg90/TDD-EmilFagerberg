using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationEngineTests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void ValidateValidEmail()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate("hello@hotmail.com");

            Assert.IsTrue(sut.IsValid);
        }

        [Test]
        public void ValidateEmailThatIsMissingAtSign()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate("hellohotmail.com");

            Assert.IsFalse(sut.IsValid);
        }
        [Test]
        public void ValidateEmailThatIsMissingDot()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate("hello@hotmailcom");

            Assert.IsFalse(sut.IsValid);
        }
        [Test]
        public void ValidateEmailThatIsNull()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate(null);

            Assert.IsFalse(sut.IsValid);
        }
    }
}