using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {

        [TestCase(0, "")]
        [TestCase(1, "1")]
        [TestCase(3, "1,2")]
        [TestCase(6, "1,2,3")]
        [TestCase(6, "1\n2,3")]
        [TestCase(3, "//;\n1;2")]
        [TestCase(2, "//;\n2;1001")]
        [TestCase(6, "//***\n1***2***3")]
        [TestCase(6, "//*%\n1*2%3")]
        [TestCase(6, "//*%\n1*2%%%3")]
        public void AddNbrReturnSum(int expected, string number)
        {

            Assert.AreEqual(expected, StringCalculator.Add(number));

        }

        [Test]
        public void AddNeagativeNumberThrowException()
        {
            var number = "1\n-2,-3";

            var exception = Assert.Throws<Exception>(() => StringCalculator.Add(number));

            Assert.AreEqual("negatives not allowed -2 -3", exception.Message);

        }
    }
}
