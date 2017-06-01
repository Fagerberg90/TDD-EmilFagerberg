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

        public void AddNbrReturnSum(int expected, string number)
        {
            Assert.AreEqual(expected,StringCalculator.Add(number));

        }






    }
}
