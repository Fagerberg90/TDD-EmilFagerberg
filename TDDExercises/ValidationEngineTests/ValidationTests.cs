using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationEngineTests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void TrueForValidAddress()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate("emil@test.com");

            Assert.IsTrue(sut.IsValid);
        }

        [Test]
        public void ValidateMissingDot()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate("emil@testcom");

            Assert.IsFalse(sut.IsValid);
        }

        [Test]
        public void ValidateMissingAtSign()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate("emiltest.com");

            Assert.IsFalse(sut.IsValid);
        }
    
        [Test]
        public void ValidateIsNull()
        {
            var sut = new ValidationEngine.ValidationEngine();

            sut.IsValid = sut.Validate(null);

            Assert.IsFalse(sut.IsValid);
        }
    }
}
